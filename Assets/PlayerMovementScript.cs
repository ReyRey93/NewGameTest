using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;

    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;

    private void Update() 
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump")) {
            isJumping = true;
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        if (isJumping && Input.GetButton("Jump")) {
            if (jumpTimer < jumpTime) {
                rb.linearVelocity = Vector2.up * jumpForce;
                jumpTimer += Time.deltaTime;
            } else {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump")) {
            isJumping = false;
            jumpTimer = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(feetPos != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(feetPos.position, groundDistance);
        }
    }
}