using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{


    public float HP = 100;

    public float range;
    public Transform target;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;
    public GameObject bullet;
    public float fireRate;
    public SpriteRenderer sprite;

    // public Animator animator;

    bool canShoot = true;
    bool isDetected = false;

    Vector2 direction;
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

        if (rayInfo)
        {
            if (!isDetected)
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

        if (isDetected)
        {
            if (canShoot)
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
        Instantiate(bullet, firePoint1.position, firePoint1.rotation);
        Instantiate(bullet, firePoint2.position, firePoint2.rotation);
        Instantiate(bullet, firePoint3.position, firePoint3.rotation);
        Instantiate(bullet, firePoint4.position, firePoint4.rotation);
        Instantiate(bullet, firePoint5.position, firePoint5.rotation);
        yield return new WaitForSecondsRealtime(fireRate);
        canShoot = true;
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        StartCoroutine(FlashRed());

        if (HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;

    }

}
