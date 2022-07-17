using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SageataScript : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 1;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        CharacterController2D character = collider.GetComponent<CharacterController2D>();
        if(character != null)
        {
            character.TakeDamage(damage);
        }
        if (collider.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
