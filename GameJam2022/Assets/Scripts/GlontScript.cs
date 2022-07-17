using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlontScript : MonoBehaviour
{
    public float damage = 50;
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag != "Player" && collider.gameObject.tag != "EnemyChecker")
        {
            WheelScript wheel = collider.GetComponent<WheelScript>();
            if (wheel != null)
            {
                wheel.TakeDamage(damage);
            }

            TurretScript turret = collider.GetComponent<TurretScript>();
            if (turret != null)
            {
                turret.TakeDamage(damage);
            }
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);
            }

        

    }

  

}
