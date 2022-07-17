using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SageataScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
