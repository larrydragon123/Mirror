using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Controller controller;
    private float horizontal;
    [SerializeField] public float speed;
    [SerializeField] public float jumpingPower;
    private bool isFacingRight = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioSource jumpSoundEffect;

    Animator playeranim;

    void Start()
    {
        controller = GetComponent<Controller>();
        playeranim = GetComponent<Animator>();
        StartCoroutine(respawnOver());
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            // rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            rb.AddForce(Vector2.up * jumpingPower, ForceMode2D.Impulse);
            playeranim.SetBool("isJumping", true);
            playeranim.SetBool("isGround", false);
        }
        else if (IsGrounded())
        {
            playeranim.SetBool("isJumping", false);
            playeranim.SetBool("isGround", true);
        }
        else
        {
            playeranim.SetBool("isJumping", true);
            playeranim.SetBool("isGround", false);
        }

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

        if (horizontal == 0)
        {
            playeranim.SetBool("isWalking", false);
        }
        else
        {
            playeranim.SetBool("isWalking", true);
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

    IEnumerator respawnOver()
    {
        yield return new WaitForSeconds(1f);
        playeranim.SetBool("RespawnEnd", true);
    }
}
