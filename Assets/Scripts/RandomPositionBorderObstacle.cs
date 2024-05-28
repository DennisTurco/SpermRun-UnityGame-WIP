using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomPositionBorderObstacle : MonoBehaviour
{
    [Header("Obstacles Spawn Settings")]
    [SerializeField] private float spawnRateMinTime;
    [SerializeField] private float spawnRateMaxTime;
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private List<float> probabilities;
    [SerializeField] private Vector2 LeftObstaclesPos;
    [SerializeField] private Vector2 RightObstaclesPos;
    [SerializeField] private Vector2 CenterObstaclesMinPos;
    [SerializeField] private Vector2 CenterObstaclesMaxPos;
    [SerializeField] private bool canSpawn = true;

    [Header("Obstacles Spawn Limits Settings")]
    [SerializeField] private bool enemyToSpawnLimit;
    [SerializeField] private int enemyToSpawn = -1; // Number of elements to spawn: negative means infinite
    [SerializeField] private int enemySpawned;

    [Header("Spawn Time Interval Limits")]
    [SerializeField] private List<float> spawnIntervalLimits; // List of time intervals for each object

    private Dictionary<GameObject, float> lastSpawnTimes; // Dictionary to keep track of last spawn times per object

    private void Start()
    {
        enemySpawned = 0;

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
            if (enemyToSpawnLimit && enemySpawned >= enemyToSpawn)
            {
                GameManager.Instance.SetGameFinished();
                yield break;
            }

            float waitTime = UnityEngine.Random.Range(spawnRateMinTime, spawnRateMaxTime);
            yield return new WaitForSeconds(waitTime);

            GameObject obstacle = GetRandomObject();
            if (obstacle == null) continue;

            Vector2 position;

            if (obstacle.CompareTag("LeftObstacle")) position = new Vector2(LeftObstaclesPos.x, LeftObstaclesPos.y);
            else if (obstacle.CompareTag("RightObstacle")) position = new Vector2(RightObstaclesPos.x, RightObstaclesPos.y);
            else if (obstacle.CompareTag("CenterObstacle")) position = new Vector2(UnityEngine.Random.Range(CenterObstaclesMinPos.x, CenterObstaclesMaxPos.x), CenterObstaclesMaxPos.y);
            else if (obstacle.CompareTag("Virus")) position = new Vector2(UnityEngine.Random.Range(CenterObstaclesMinPos.x, CenterObstaclesMaxPos.x), CenterObstaclesMaxPos.y);
            else throw new Exception("Invalid or missing tag on the object");

            Instantiate(obstacle, position, Quaternion.identity);

            Debug.Log($"Object {obstacle.tag} spawned at position: ({position.x}, {position.y})");
            enemySpawned++;
            lastSpawnTimes[obstacle] = Time.time; // Update the last spawn time for this object
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
