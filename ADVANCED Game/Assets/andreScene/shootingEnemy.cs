using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingEnemy : MonoBehaviour {

    private Transform playerTransform;
    private RaycastHit hit;
    public float range = 400;

    public TargetCollision tCollider;

    void Start()
    {
        playerTransform = transform.parent;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.log("urDeadKiddo");

            if (Physics.Raycast(playerTransform.TransformPoint (new Vector3(Random.Range(-1,1), Random.Range(-1,1),1)), playerTransform.forward, out hit, range))
            {
                if (hit.collider.tag == "target")
                {
                    tCollider = hit.transform.gameObject.GetComponent<TargetCollision>();
                    tCollider.BreakTarget();
                    //Destroy(hit.transform.gameObject);
                    Debug.Log("ShotEnemy");
                }
            }

        }
    }
}
