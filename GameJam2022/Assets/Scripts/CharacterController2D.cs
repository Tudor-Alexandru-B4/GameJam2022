using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class CharacterController2D : MonoBehaviour
{
    // Move player in 2D space
    public float HP = 1000;
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    private Camera mainCamera;
    public Animator animator;
    public SpriteRenderer sprite;
    bool dead = false;

    public Slider slider;

    private UI_Inventory inventory;

    public bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;
    DiceGuns diceGuns;

    // Use this for initialization

    void Awake()
    {
        slider = GameObject.Find("legatura").GetComponent<Slider>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        inventory = GameObject.Find("UI_Inventory").GetComponent<UI_Inventory>();
    }

    void Start()
    {
        diceGuns = DiceDataBase.Instance.diceGuns;
        //inventory.setDice(diceGuns);
        SetMaxHealth((int)HP);
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;

        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!dead)
        {
            // Movement controls
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (isGrounded || Mathf.Abs(r2d.velocity.x) > 0.01f))
            {
                moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
                //Animator
                animator.SetFloat("Speed", 10);
            }
            else
            {
                if (isGrounded || r2d.velocity.magnitude < 0.01f)
                {
                    moveDirection = 0;
                    //Animator
                    animator.SetFloat("Speed", 0);
                }
            }

            // Change facing direction
            if (moveDirection != 0)
            {

                if (moveDirection > 0 && !facingRight)
                {
                    facingRight = true;
                    t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
                    //t.Rotate(0f, 180f, 0f);

                }
                if (moveDirection < 0 && facingRight)
                {
                    facingRight = false;
                    t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
                    //t.Rotate(0f, 180f, 0f);

                }
            }

            if (Input.GetKeyDown(KeyCode.M))
            {

                if (!GameObject.Find("Canvas").GetComponent<Canvas>().enabled)
                {
                    inventory.setDice(diceGuns);
                }

                GameObject.Find("Canvas").GetComponent<Canvas>().enabled = !GameObject.Find("Canvas").GetComponent<Canvas>().enabled;
            }

            // Jumping
            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
                //animator.SetBool("isJumping", true);

            }

            if (isGrounded)
            {
                animator.SetBool("isJumping", false);
            }
            else
            {
                animator.SetBool("isJumping", true);
            }


            // Camera follow
            if (mainCamera)
            {
                mainCamera.transform.position = new Vector3(t.position.x, t.position.y, cameraPos.z);
            }

            SetHealth((int)HP);

            if (HP <= 0)
            {
                Die();
                dead = true;
            }
        }

    }

    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.tag != "Player" && colliders[i].gameObject.tag != "Enemy" && colliders[i].gameObject.tag != "EnemyChecker")
                {
                    isGrounded = true;
                    break;
                }
            }
        }

        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), isGrounded ? Color.green : Color.red);
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), isGrounded ? Color.green : Color.red);
    }

    public void updateDiceGun(DiceGuns diceGun)
    {
        this.diceGuns = diceGun;
        inventory.setDice(diceGun);
    }

    public void changeGun(Gun gunToChange)
    {
        DiceDataBase.Instance.currentGun = gunToChange;
        Instantiate(gunToChange.getPrefab(),t.position,t.rotation);
        Destroy(gameObject);
    }

    public void diceAnim()
    {
        StartCoroutine(inventory.rollAnimation());
    }

    public void chamberEnd()
    {
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
        inventory.setDice(diceGuns);
    }

    public void loadRandomScene()
    {
        SceneManager.LoadScene(Random.Range(2, 4));
    }

    public void TakeDamage(float damage)
    {
        StartCoroutine(FlashRed());
        HP -= damage;
        if(HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Destroy(gameObject);
        SceneManager.LoadScene(0);
        StartCoroutine(restart());
        SceneManager.LoadScene(1);
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(2);
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

}