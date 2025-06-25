using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public partial class PlayerController : MonoBehaviour
{
    void UpdateAnimation()
    {

        if (Input.GetKey(KeyCode.J))
        {
            ChangeState(PlayerState.Attack);
        }
        else if (isClimbing)
        {
            ChangeState(PlayerState.Climb);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            ChangeState(PlayerState.Roll);
        }
        else if (!isGrounded)
        {
            if (rb.linearVelocity.y > 0.1f)
            {
                ChangeState(PlayerState.Jump);
            }
            else if (rb.linearVelocity.y < -0.1f)
            {
                ChangeState(PlayerState.Fall);
            }
        }
        else
        {
            if (currentState == PlayerState.Fall)
            {
                ChangeState(PlayerState.Idle);
            }
            else if (rb.linearVelocity.x != 0)
            {
                ChangeState(PlayerState.Run);
            }
            else
            {
                ChangeState(PlayerState.Idle);
            }
        }

    }

    void ChangeState(PlayerState newState)
    {
        if (currentState == newState) return;

        currentState = newState;

        switch (currentState)
        {
            case PlayerState.Idle:
                ani.SetBool("Fall", false);
                ani.SetBool("Climb", false);
                ani.SetFloat("Movement", 0);
                break;
            case PlayerState.Run:
                ani.SetFloat("Movement", 1);
                break;
            case PlayerState.Jump:
                ani.SetTrigger("Jump");
                break;
            case PlayerState.Fall:
                ani.SetBool("Fall", true);
                break;
            case PlayerState.Attack:
                ani.SetTrigger("Attack");
                break;
            case PlayerState.Roll:
                StartCoroutine(Roll_IEnumerator());
                break;
            case PlayerState.Climb:
                ani.SetBool("Climb", true);
                break;

        }
    }

    IEnumerator Roll_IEnumerator()
    {
        ani.SetBool("Roll", true);
        isRolling = true;
        rb.linearVelocity = new Vector2(x * moveSpeed * 3, rb.linearVelocity.y);
        yield return new WaitForSeconds(0.2f); // Thời gian lăn
        ani.SetBool("Roll", false);
        isRolling = false;
        rb.linearVelocity = new Vector2(x * moveSpeed, rb.linearVelocity.y);
    }
}
