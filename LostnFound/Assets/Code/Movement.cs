using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    Vector2 movement;
    private bool jumped;
    public float jumpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        jumped = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            movement.y = 1.0f;
            jumped = true;
        }
        else movement.y = 0.0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        jumped = false;
    }
    private void FixedUpdate()
    {
        Vector2 pos = rb.position + movement * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }
}
