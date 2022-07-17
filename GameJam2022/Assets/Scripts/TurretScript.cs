using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float HP = 100;
    public SpriteRenderer sprite;
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
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        target = GameObject.FindWithTag("Player").GetComponent<Transform>();

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

    public void TakeDamage(float damage)
    {
        HP -= damage;
        StartCoroutine(FlashRed());
        if (HP <= 0)
        {
            Destroy(gameObject);
        }    
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        sprite.color = Color.white;

    }
}
