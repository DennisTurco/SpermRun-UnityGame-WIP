using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomPositionBorderPicks : MonoBehaviour
{
    [Header("Picks Spawn Settings")]
    [SerializeField] private float spawnRateMinTime;
    [SerializeField] private float spawnRateMaxTime;
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private List<float> probabilities;
    [SerializeField] private Vector2 CenterPickMinPos;
    [SerializeField] private Vector2 CenterPickMaxPos;
    [SerializeField] private bool canSpawn = true;

    [Header("Picks Spawn Limits Settings")]
    [SerializeField] private bool pickToSpawnLimit;
    [SerializeField] private int pickToSpawn = -1; // Number of elements to spawn: negative means infinite
    [SerializeField] private int pickSpawned;

    [Header("Spawn Time Interval Limits")]
    [SerializeField] private List<float> spawnIntervalLimits; // List of time intervals for each object

    private Dictionary<GameObject, float> lastSpawnTimes; // Dictionary to keep track of last spawn times per object

    private void Start()
    {
        pickSpawned = 0;

        if (objects.Count != probabilities.Count || objects.Count != spawnIntervalLimits.Count)
        {
            Debug.LogError("Objects, probabilities, and spawn interval limits counts do not match.");
            return;
        }

        lastSpawnTimes = new Dictionary<GameObject, float>();
        foreach (var obj in objects)
        {
            lastSpawnTimes[obj] = -Mathf.Infinity; // Initialize with -Infinity to allow immediate spawn at start
        }

        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (canSpawn && objects.Count > 0)
        {
            if (pickToSpawnLimit && pickSpawned >= pickToSpawn)
            {
                GameManager.Instance.SetGameFinished();
                yield break;
            }

            float waitTime = UnityEngine.Random.Range(spawnRateMinTime, spawnRateMaxTime);
            yield return new WaitForSeconds(waitTime);

            GameObject pickObject = GetRandomObject();
            if (pickObject == null) continue;

            Vector2 position;
            if (pickObject.CompareTag("Coin")) position = new Vector2(UnityEngine.Random.Range(CenterPickMinPos.x, CenterPickMaxPos.x), CenterPickMaxPos.y);
            else if (pickObject.CompareTag("Syringe")) position = new Vector2(UnityEngine.Random.Range(CenterPickMinPos.x, CenterPickMaxPos.x), CenterPickMaxPos.y);
            else if (pickObject.CompareTag("Redbull")) position = new Vector2(UnityEngine.Random.Range(CenterPickMinPos.x, CenterPickMaxPos.x), CenterPickMaxPos.y);
            else throw new Exception("Invalid or missing tag to the object");

            Instantiate(pickObject, position, Quaternion.identity);

            Debug.Log($"Object {pickObject.tag} spawned at position: ({position.x}, {position.y})");
            pickSpawned++;
            lastSpawnTimes[pickObject] = Time.time; // Update the last spawn time for this object
        }
    }

    private GameObject GetRandomObject()
    {
        float totalProbability = probabilities.Sum();
        float randomPoint = UnityEngine.Random.value * totalProbability;

        for (int i = 0; i < probabilities.Count; i++)
        {
            if (randomPoint < probabilities[i])
            {
                if (Time.time - lastSpawnTimes[objects[i]] >= spawnIntervalLimits[i]) // Check if enough time has passed since the last spawn
                {
                    return objects[i];
                }
            }
            randomPoint -= probabilities[i];
        }

        return null; // Shouldn't happen
    }
}
