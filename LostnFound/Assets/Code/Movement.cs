using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        if (movement.x != 0)
            transform.localScale = new Vector3(5.0f * movement.x, 5.0f, 1.0f);
        Vector2 pos = rb.position + movement * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }
}
