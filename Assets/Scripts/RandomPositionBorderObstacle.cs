﻿using System;
using System.Collections;
using UnityEngine;

public class RandomPositionBorderObstacle : MonoBehaviour
{
    [Header("Obstacles Spawn Settings")]
    [SerializeField] private float spawnRateMinTime = 1f;
    [SerializeField] private float spawnRateMaxTime = 5f;
    [SerializeField] private GameObject[] objectsPool;
    [SerializeField] private Vector2 LeftObstaclesPos;
    [SerializeField] private Vector2 RightObstaclesPos;
    [SerializeField] private bool canSpawn = true;

    [Header("Obstacles Spawn Limits Settings")]
    [SerializeField] private bool enemyToSpawnLimit;
    [SerializeField] private int enemyToSpawn = -1; // Number of elements to spawn: negative means infinite
    [SerializeField] private int enemySpawned;

    // Use this for initialization
    private void Start()
    {
        enemySpawned = 0;

        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(UnityEngine.Random.Range(spawnRateMinTime, spawnRateMaxTime));

        while (canSpawn && objectsPool.Length > 0)
        {
            if (enemyToSpawnLimit && enemySpawned >= enemyToSpawn)
            {
                GameManager.Instance.SetGameFinished();
                yield break;
            }

            yield return wait;


            // check type of obstacle and spawn it
            int rand = UnityEngine.Random.Range(0, objectsPool.Length);
            Vector2 position;
            
            if (objectsPool[rand].CompareTag("LeftObstacle")) position = new Vector2(LeftObstaclesPos.x, LeftObstaclesPos.y);
            else if (objectsPool[rand].CompareTag("RightObstacle")) position = new Vector2(RightObstaclesPos.x, RightObstaclesPos.y);
            else throw new Exception("Invalid or missing tag to the object");

            GameObject enemyObject = Instantiate(objectsPool[rand], position, Quaternion.identity);

            Debug.Log($"Object spawned at position: ({position.x}, {position.y})");
            enemySpawned++;
        }
    }
}