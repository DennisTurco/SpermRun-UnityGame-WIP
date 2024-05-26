using System;
using System.Collections;
using UnityEngine;

public class RandomPositionBorderPicks : MonoBehaviour
{
    [Header("Picks Spawn Settings")]
    [SerializeField] private float spawnRateMinTime;
    [SerializeField] private float spawnRateMaxTime;
    [SerializeField] private GameObject[] objectsPool;
    [SerializeField] private Vector2 CenterPickMinPos;
    [SerializeField] private Vector2 CenterPickMaxPos;
    [SerializeField] private bool canSpawn = true;

    [Header("Picks Spawn Limits Settings")]
    [SerializeField] private bool pickToSpawnLimit;
    [SerializeField] private int pickToSpawn = -1; // Number of elements to spawn: negative means infinite
    [SerializeField] private int pickSpawned;

    // Use this for initialization
    private void Start()
    {
        pickSpawned = 0;

        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(UnityEngine.Random.Range(spawnRateMinTime, spawnRateMaxTime));

        while (canSpawn && objectsPool.Length > 0)
        {
            if (pickToSpawnLimit && pickSpawned >= pickToSpawn)
            {
                GameManager.Instance.SetGameFinished();
                yield break;
            }

            yield return wait;


            // check type of pick and spawn it
            int rand = UnityEngine.Random.Range(0, objectsPool.Length);
            Vector2 position;

            if (objectsPool[rand].CompareTag("Coin")) position = new Vector2(UnityEngine.Random.Range(CenterPickMinPos.x, CenterPickMaxPos.x), CenterPickMaxPos.y);
            else throw new Exception("Invalid or missing tag to the object");

            GameObject pickObject = Instantiate(objectsPool[rand], position, Quaternion.identity);

            Debug.Log($"Object {objectsPool[rand].tag} spawned at position: ({position.x}, {position.y})");
            pickSpawned++;
        }
    }
}
