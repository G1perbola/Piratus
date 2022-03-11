using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed = 10f;
    public Animator anim;
    public bool faceRight = true;
    float SX, SY;
    public bool onGround;
    public Transform GroundCheck;
    public float jumpForce = 7f;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    public float checkRadius = 0.05f;
    public LayerMask Ground;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SX = transform.position.x;
        SY = transform.position.y;
    }

    void Update()
    {
        walk();
        Reflect();
        Jump();
        CheckingGround();
    }
    void walk()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
    }
    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //rb.AddForce(Vector2.up * jumpForce);
        }
    }
 /*   void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }*/

  void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position,checkRadius, Ground);
        anim.SetBool("onGround", onGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "DeadZone")
        {
            transform.position = new Vector3(SX, SY, transform.position.z);
        }
        if (collision.gameObject.name == "Checkpoint")
        {
            SX = transform.position.x;
            SY = transform.position.y;
            Destroy(GameObject.FindWithTag("Checkpoint"));
        }
    }
    }
