using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour {

    public GameObject full;
    public GameObject shards;
    public GameObject tBase;
    public TargetSpawner spawner;

    void Start ()
    {
        spawner = GameObject.FindWithTag("spawner").GetComponent<TargetSpawner>();
    }

    public void BreakTarget()
    {
        full.SetActive(false);
        shards.SetActive(true);
        spawner.numOfTargets -= 1;

        Destroy(tBase, 10);
    }
}
