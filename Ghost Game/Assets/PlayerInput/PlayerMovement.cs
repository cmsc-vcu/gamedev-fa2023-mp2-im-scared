using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;

    private Rigidbody2D rb;
    private Transform groundCheck;
    private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // check if jump button is pressed and player is on ground
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            // jumping velocity
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
    }

    // Check if player is on the ground
    private bool IsGrounded()
    {
        // creates circle around player's feet, if it collides, player can jump
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
}
