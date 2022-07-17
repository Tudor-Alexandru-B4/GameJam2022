using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

    public float range;
    public Transform target;
    public Transform firePoint;
    public GameObject bullet;
    public float fireRate;
   // public Animator animator;

    bool canShoot = true;
    bool isDetected = false;

    Vector2 direction;

    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPosition = target.position;

        direction = targetPosition - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, range);

        if(rayInfo)
        {
            if(!isDetected)
            {
                isDetected = true;
                //animator.SetBool("isAgroed", true);
                //Debug.Log("Detectat");
            }
            else
            {
               // animator.SetBool("isAgroed", false);
                isDetected = false;
                //Debug.Log("Nedetectat");
            }
        }
        
        if(isDetected)
        {
            gun.transform.up = direction * -1;
            if(canShoot)
            {
               StartCoroutine(Shoot());
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        yield return new WaitForSecondsRealtime(fireRate);
        canShoot = true;
    }
}
