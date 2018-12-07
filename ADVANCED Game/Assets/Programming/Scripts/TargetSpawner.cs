using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetSpawner : MonoBehaviour {

    public GameObject target;
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    private float timeToSpawn;

    public float numOfTargets;
    public float maxTargets;
    public float spawnTime;

	void Start ()
    {
        timeToSpawn = 0f;

        for (int i = 0; i < 5; i++)
        {
            SpawnTarget();
            numOfTargets += 1;
        }
	}
	
	void Update ()
    {
        timeToSpawn -= Time.deltaTime;

        if (timeToSpawn <= 0f && numOfTargets < maxTargets)
        {
            SpawnTarget();
            numOfTargets += 1;
            timeToSpawn = spawnTime;
        }
	
	}
     
    public void SpawnTarget ()
    {
        Instantiate(target, new Vector3(Random.Range(xMin, xMax), 0, Random.Range(zMin, zMax)), Quaternion.identity);
        
    }
}
