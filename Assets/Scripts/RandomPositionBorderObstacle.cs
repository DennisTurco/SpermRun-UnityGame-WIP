using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionBorderObstacle : MonoBehaviour
{
    // Used to randomly generate X offset
    public float minPosX = -5.6f;
    public float maxPosX = -5.6f;
    // Used to randomly generate Y offset
    public float minPosY = 5.16f;
    public float maxPosY = 5.16f;
    // Used to set a random spawn frequency
    public float minSpawnTime = 5f;
    public float maxSpawnTime = 20f;
    // The pool of objects we want to spawn
    public GameObject[] objectsPool;
    // Number of elements to spawn: negative means infinite
    public int elemToSpawn = -1;

    int elemCounter;
    Queue<GameObject> objectsQueue;

    // Use this for initialization
    void Start()
    {
        // Populate queue
        objectsQueue = new Queue<GameObject>();
        foreach (GameObject go in objectsPool)
        {
            objectsQueue.Enqueue(go);
        }
        Invoke("Spawn", Random.Range(minSpawnTime, maxSpawnTime));
    }

    // This is called recursevly to spawn an object
    void Spawn()
    {
        if ((elemToSpawn < 0 || elemCounter++ <= elemToSpawn) && objectsQueue.Count > 0)
        {
            GameObject objectToSpawn = objectsQueue.Dequeue();
            Vector3 newPos = transform.position;
            newPos.x += Random.Range(minPosX, maxPosX);
            newPos.y += Random.Range(minPosY, maxPosY);
            objectToSpawn.transform.position = newPos;
            objectToSpawn.SetActive(true);
        }
        Invoke("Spawn", Random.Range(minSpawnTime, maxSpawnTime));
    }

    // Requeue object
    public void RequeueObject(GameObject obj)
    {
        obj.SetActive(false);
        objectsQueue.Enqueue(obj);
    }

}
