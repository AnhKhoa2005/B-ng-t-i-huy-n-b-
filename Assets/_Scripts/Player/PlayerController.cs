using System;
using UnityEngine;

public partial class PlayerController : MonoBehaviour, ITakeDamage
{
    [Header("\tProperties\t")]
    [SerializeField] public float health = 100f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] Bow bow;

    Rigidbody2D rb;
    Animator ani;
    SpriteRenderer sr;
    float x, y;
    public bool isRolling = false, isGrounded = false, isDoubleJumping = false, isClimbing = false;

    enum PlayerState
    {
        Idle,
        Run,
        Jump,
        Fall,
        Attack,
        Roll,
        Climb
    }
    PlayerState currentState = PlayerState.Idle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        bow = GetComponentInChildren<Bow>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        Move();
        Jump();
        Attack();
        Flip();
        UpdateAnimation();
    }
}
