using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] spawnLocations;
    public float waitTime = 5;
    private bool timer;

    private void Start()
    {
        timer = true;
    }

    private void Update()
    {
        if (timer)
        {
            StartCoroutine(Spawner());
        }
    }

    private IEnumerator Spawner()
    {
        timer = false;
        yield return new WaitForSeconds(waitTime);

        int spawnThisMuch = (int)Random.Range(1, 3);
        bool[] spots = new bool[spawnLocations.Length];

        for (int i = 0; i < spawnThisMuch; i++)
        {// Randomly picks a bool to flip - Even if the spawn wants 3, it may not happen
            spots[(int)Random.Range(0, spots.Length)] = true;
        }

        for (int i = 0; i < spots.Length; i++)
        {
            if (spots[i])
            {
                GameObject obstacle = Instantiate(prefabs[Random.Range(0, prefabs.Length - 1)]); // Spawn From Prefab Array
                obstacle.transform.position = spawnLocations[i].position; // move object to Spawn Location
                obstacle.tag = "Obstacle";
            }
        }
        timer = true;
    }
}
