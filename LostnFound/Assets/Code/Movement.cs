using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool facingRight = true;

    
    private bool isGrounded;
    public Transform groundCheck;
    public float CheckRadius;
    public LayerMask whatIsGround;
    public int havejumped;
    //private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        { havejumped = 0; }
        if (Input.GetKeyDown(KeyCode.W) && havejumped > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            havejumped--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && havejumped == 0 && isGrounded==true) 
        { rb.velocity = Vector2.up * jumpForce;}

        //if (rb.velocity.x > 0) { }
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) { anim.Play("Walk"); }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {

            Debug.Log("touching");
        }

    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            flip();
        }
    }
}
