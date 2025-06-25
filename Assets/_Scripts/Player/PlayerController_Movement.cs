using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerController : MonoBehaviour
{
    void Move()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * 7, Input.GetAxisRaw("Vertical") * 7);
            return;
        }
        else
        {
            rb.gravityScale = 3f;
        }
        if (Input.GetKey(KeyCode.A))
            x = -1f;
        else if (Input.GetKey(KeyCode.D))
            x = 1f;
        else
            x = 0f;
        if (isRolling) return;
        rb.linearVelocity = new Vector2(x * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (isClimbing) return;
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                AudioManagers.Instance.SFXPlay(AudioManagers.Instance.JumpClip);
                isDoubleJumping = true;
            }
            else if (isDoubleJumping)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                AudioManagers.Instance.SFXPlay(AudioManagers.Instance.JumpClip);
                isDoubleJumping = false;
            }
        }
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayerMask);
    }

    void Flip()
    {
        if (x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (x > 0)
            transform.localScale = new Vector3(1, 1, 1);
    }

}
