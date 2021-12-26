using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class NewController : MonoBehaviour

{
    public GameObject SceneGameOver;

    public Text timeSec;
    public Text timeMin;
    public Text Score;
    
    public Vector3 MovingDirection;
    public float JumpingForce;
    
    public static float movingSpeed = 10f;

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
    public bool isGrounded;

    //Jump
    //float jumpForce;
    //public float gravityScale = 5;

    //clock
    float sec=0;
    float min=0;
    float score = 0;
    void Start()
    {
       
        SceneGameOver = GameObject.Find("GameOver");
        SceneGameOver.gameObject.SetActive(false);
        rotateRate = 1 / rotateDuration;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
      
    }
    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * movingSpeed * Time.deltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * movingSpeed * Time.deltaTime * horizontalMultiplier;
        if (alive)
        {
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        }
    }
    public void Die()
    {
        SceneGameOver.gameObject.SetActive(true);
        alive = false;
        score = (float)((min * 60 + sec) * 1.5 + GameManager.score);
        Score.text = ((int)score).ToString();
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    void Update()
    {
        
       // if (!alive) return;
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5)
        {
            Die();
        }
        
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
        if(isGrounded)
        {
            jump = false;
            run = true;
        }
        else
        {
            run = false;
            jump = true;
        }
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //Debug.Log("Jumping");
            jump = true;
            rb.AddForce(JumpingForce * Vector3.up);
            
        }
        animator.SetBool("Die", alive);
        animator.SetBool("Run", run);
        animator.SetBool("Jump", jump);
        if (alive)
        {
            sec += Time.deltaTime;
            timeSec.text = ((int)sec).ToString();
            timeMin.text = min.ToString();
            if (sec >= 60)
            {
                min++;
                sec = 0;
            }
        }
    }
    }
    


