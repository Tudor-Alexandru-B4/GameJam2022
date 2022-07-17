using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrol : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;

    public float speed;

    public Collider2D bodyCollider;

    public LayerMask groundLayer;

    public Transform groundCheckPos;

    private bool mustTurn;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if(mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }

        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);

    }
    void Flip()
    {
        mustPatrol = false;
        //transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        transform.Rotate(0f, 180f, 0f);
        speed *= -1;
        mustPatrol = true;
    }
}
