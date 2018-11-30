using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour {

    public GameObject full;
    public GameObject shards;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            full.SetActive(false);
            shards.SetActive(true);
        }
    }
}
