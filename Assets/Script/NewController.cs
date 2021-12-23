using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class NewController : MonoBehaviour

{

    public Vector3 MovingDirection;
    public float JumpingForce;
    [SerializeField] float movingSpeed = 10f;

    Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;
    bool alive = true;
    //animator
    Animator animator;
    bool onGround = true, run = false;
    bool jump = false;
    bool isFall = false;


    //rotate
    float rotateRate;
    float rotateDuration = 0.2f;
    float rotateTime=0;
    Quaternion nowRotation;
    Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
    float degree = 0;
    bool IsTurn = false;

    //Ground
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    //Jump
    //float jumpForce;
    //public float gravityScale = 5;
    void Start()
    {
       
        rotateRate = 1 / rotateDuration;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
      
    }
    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * movingSpeed * Time.deltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * movingSpeed * Time.deltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    public void Die()
    {
        alive = false;

        Invoke("Restart", 2);
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    void Update()
    {
        if (!alive) return;
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5)
        {
            Die();
        }

        if (!isFall && !jump)
        {
            run = true;
        }else
        {
            run = false;

        }
        //transform.position += movingSpeed * Time.deltaTime * transform.forward;
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
                nowRotation = targetRotation;
                degree -= 90;
                IsTurn = true;
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
                nowRotation = targetRotation;
                degree += 90;
                IsTurn = true;
        }
        if (IsTurn)
        {
            
            targetRotation = Quaternion.Euler(0, degree, 0);
            rotateTime += Time.deltaTime*rotateRate;

            transform.rotation = Quaternion.Slerp(nowRotation, targetRotation, rotateTime);
            if (rotateTime > 1f)
            {
                transform.rotation = Quaternion.Slerp(nowRotation, targetRotation, 1);
                IsTurn = false;
                rotateTime = 0;
            }
          
        }
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if (Input.GetButton("Jump") && isGrounded)
        {
            jump = true;
            rb.AddForce(JumpingForce * Time.deltaTime * Vector3.up);
            
        }
        if(rb.velocity.y < 0 && !isGrounded)
        {
            run = false;
            isFall = true;
            jump = false;
        }
        if (isGrounded)
        {
            isFall = false;
        }
        
         animator.SetBool("Run", run);
         animator.SetBool("Jump", jump);
        animator.SetBool("isFall", isFall);
    }
    }
    


