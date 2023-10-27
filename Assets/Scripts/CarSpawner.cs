using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] spawnLocations;
    public Vector2 waitTime = new Vector2(2, 5);
   
    
    private bool timer;

    private void Start()
    {
        timer = true;
        StartCoroutine(increaseDifficulty());
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
        yield return new WaitForSeconds(Random.Range(waitTime.x,waitTime.y));

        int spawnThisMuch = (int)Random.Range(1, spawnLocations.Length);
        bool[] spots = new bool[spawnLocations.Length];

        for (int i = 0; i < spawnThisMuch; i++)
        {// Randomly picks a bool to flip - Even if the spawn wants 3, it may not happen
            bool updated = false;
            do
            {
                int temp = (int)Random.Range(0, spots.Length);
                if (!spots[temp])
                {
                    spots[temp] = true;
                    updated = true;
                }
            }
            while (!updated);
            
        }

        for (int i = 0; i < spots.Length; i++)
        {
            if (spots[i])
            {
                GameObject obstacle = Instantiate(prefabs[Random.Range(0, prefabs.Length - 1)]); // Spawn From Prefab Array
                obstacle.transform.position = spawnLocations[i].position; // move object to Spawn Location
            }
        }
        timer = true;
    }
    

    private IEnumerator increaseDifficulty()
    {

        yield return new WaitForSeconds(30);

        waitTime.y -= 1;

        yield return new WaitForSeconds(30);

        waitTime.y -= 1;
    }
}
