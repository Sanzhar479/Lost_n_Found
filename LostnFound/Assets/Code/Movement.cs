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
        if (jumped == false)
        {
            movement.y = Mathf.Abs(Input.GetAxisRaw("Vertical"));
            jumped = true;
        }
        //if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))/* && jumped == false*/)
        //{
        //    movement.y = 1.0f;
        //    jumped = true;
        //}
        //else movement.y = 0.0f;
    }
    void Collision2D(Collision collision)
    {
        Debug.Log("Enter");
        jumped = false;
    }
    private void FixedUpdate()
    {
        Vector2 pos;
        pos.x = rb.position.x + movement.x * speed * Time.fixedDeltaTime;
        pos.y = rb.position.y + movement.y * jumpSpeed * Time.fixedDeltaTime;

        rb.MovePosition(pos);
    }
}
