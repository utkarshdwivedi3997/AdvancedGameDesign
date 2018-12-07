using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class shootingEnemy : MonoBehaviour {
    [SerializeField]
    private MouseLook m_MouseLook;
    private Transform playerTransform;
    private RaycastHit hit;
    public float range = 400;

    private TargetCollision tCollider;
    
    [SerializeField]
    private LayerMask whatIsShootable;

    [SerializeField]
    private Transform camera;

    // Scope variables
    private bool isScoped;
    [SerializeField]
    private Animator weaponAnimator;

    // Recoil
    [SerializeField]
    private float zRecoilAmt = 0.1f;
    [SerializeField]
    private float recoilRecoveryTime = 0.3f;
    [SerializeField]
    private float maxZRecoilVal = 0.5f, maxZRecoilValScoped = 0.01f;
    private float currRecoilZPos, currRecoilZVel;
    void Start()
    {
        playerTransform = transform;
        isScoped = false;

        m_MouseLook.Init(transform, camera.transform);
        currRecoilZPos = 0f;
    }
    void Update()
    {
        // Mouse look
        m_MouseLook.LookRotation(transform, camera.transform);

        //Debug.DrawRay(camera.position, camera.forward * range, Color.green, 0.1f, false);

        if (Input.GetButtonDown("Fire1"))
        {
            // recoil
            //if (!isScoped)
            currRecoilZPos -= zRecoilAmt;

            //Debug.Log("urDeadKiddo");
            // Changed this line a lil bit
            //if (Physics.Raycast(playerTransform.TransformPoint(new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 1)), playerTransform.forward, out hit, range))
            if (Physics.Raycast(camera.position, camera.forward, out hit, range, whatIsShootable))
            {
                if (hit.collider.tag == "target")
                {
                    tCollider = hit.transform.gameObject.GetComponent<TargetCollision>();

                    // Utkarsh: added null check just to make sure things don't break
                    if (tCollider != null)
                    {
                        tCollider.BreakTarget();
                        //Debug.Log("ShotEnemy");
                        //Destroy(hit.transform.gameObject);
                    }
                }
            }
        }
        float minRecoil = isScoped ? -maxZRecoilValScoped : -maxZRecoilVal;
        currRecoilZPos = Mathf.Clamp(currRecoilZPos, minRecoil, 0);
        currRecoilZPos = Mathf.SmoothDamp(currRecoilZPos, 0, ref currRecoilZVel, recoilRecoveryTime);

        // Scope
        if (Input.GetButtonDown("Scope"))
        {
            isScoped = true;
            weaponAnimator.SetBool("Scoped", isScoped);
        }
        if (Input.GetButtonUp("Scope"))
        {
            isScoped = false;
            weaponAnimator.SetBool("Scoped", isScoped);
        }

        // Mouse cursor
        m_MouseLook.UpdateCursorLock();
        
    }

    private void LateUpdate()
    {
        //Vector3 recoilPos = Quaternion.Euler(weaponAnimator.transform.rotation.x, weaponAnimator.transform.rotation.y, 0) * new Vector3(0, 0, currRecoilZPos);
        weaponAnimator.transform.position += weaponAnimator.transform.forward * currRecoilZPos;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(playerTransform.position, 0.2f);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(playerTransform.position, playerTransform.forward * range);
    }
}
