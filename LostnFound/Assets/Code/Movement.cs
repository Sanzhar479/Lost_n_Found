using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    Vector2 movement;
    private bool jumped=false;
    public float jumpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") || jumped == false)
        {
            movement.y = 1.0f;
            jumped = true;
            
       }
        else { movement.y = 0f; }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            jumped = false;
            Debug.Log("touching");
        }
        
    }
    private void FixedUpdate()
    {
        Vector2 pos;
        pos.x = rb.position.x + movement.x * speed * Time.fixedDeltaTime;
        pos.y = rb.position.y + movement.y * jumpSpeed * Time.fixedDeltaTime;

        rb.MovePosition(pos);
    }
}
