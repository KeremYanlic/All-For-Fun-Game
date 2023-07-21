using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    public Action<PlayerMovement, PlayerMovementArgs> OnJump;

    public void CallOnJump(float jumpForce)
    {
        OnJump?.Invoke(this, new PlayerMovementArgs { jumpForce = jumpForce });
    }

    public class PlayerMovementArgs : EventArgs
    {
        public float jumpForce;
    } 


    private Rigidbody2D playerRB;
    private Animator animator;
    
    public bool isGround = true;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundCheckLayer;

    private float nextJumpTime;
    private float jumpFrequency = 0.01f;


    
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


        OnJump += OnJump_OnJumpArgs;
        
    }

   

    // Update is called once per frame
    void Update()
    {
        Movement();
        GroundCheck();
        SetAnimations();


        if(Input.GetKeyDown(KeyCode.W) || Input.GetMouseButtonDown(0))
        {
            if (isGround && nextJumpTime < Time.timeSinceLevelLoad)
            {
                nextJumpTime = jumpFrequency + Time.timeSinceLevelLoad;
                CallOnJump(jumpForce);
               
            }
           
          
        }
        
    }


    private void Movement()
    {
        transform.position += (Vector3)Vector2.right * moveSpeed * Time.deltaTime * transform.localScale.x;
       
        
    }

    private void OnJump_OnJumpArgs(PlayerMovement obj, PlayerMovementArgs arg)
    {
        Jump(arg.jumpForce);
    }
    private void Jump(float jumpForce)
    {
        playerRB.velocity = Vector2.up * jumpForce;
     //   playerRB.AddForce(new Vector2(0, jumpForce));
    }
    private void GroundCheck()
    {
        isGround = Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, groundCheckLayer);
    }
    private void SetAnimations()
    {
        if (isGround)
        {
            animator.SetBool("isGround", true);
        }
        else
        {
            animator.SetBool("isGround", false);
        }
    }
}
