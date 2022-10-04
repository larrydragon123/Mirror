using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Controller controller;
    private float horizontal;
    [SerializeField] private float speed;
    [SerializeField] private float jumpingPower;
    private bool isFacingRight = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        controller = GetComponent<Controller>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            // rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            rb.AddForce(Vector2.up * jumpingPower, ForceMode2D.Impulse);
        }

        // if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        // }

        Flip();
    }

    private void FixedUpdate()
    {
        if (controller.isReal)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-horizontal * speed, rb.velocity.y);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (controller.isReal)
        {
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
        else
        {
            if (isFacingRight && horizontal > 0f || !isFacingRight && horizontal < 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
    }
}
