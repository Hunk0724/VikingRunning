using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class TempleController : MonoBehaviour
    //只有繼承MonoBehavior才能被掛到component上
{

    public Vector3 MovingDirection;
    public float JumpingForce;
    [SerializeField]float movingSpeed = 10f;

    Rigidbody rb;

    Animator animator;
    bool onGround = true, run = false;
    RaycastHit raycastHit;
    //NavMeshAgent agent;

    //Ground
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;


    //Jump
    public float gravity = -0.981f;
    Vector3 DownfallSpeed;
    public float jumpHeight = 1.0f;

    //MeshRenderer mr;
    Quaternion _sphereOriginRotation;
    void Start()
    {
        //Debug.Log("Start");
        Transform t = GetComponent<Transform>();
        //mr = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        t.position = Vector3.one; //絕對位子

        //agent = GetComponent<NavMeshAgent>();
        _sphereOriginRotation = transform.rotation;
    }
    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("fly");
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false ;
        }
    }  
    */
    // Update is called once per frame
    void Update()
    {
        
        move();
        //transform.localPosition += movingSpeed * Time.deltaTime * MovingDirection;

        //mr.material.color = new Color((int)Time.time % 2 * 255f, 255f, 255f);
        // Debug.Log("update");
        /*if (Input.GetKey(KeyCode.W))
        {   //相對parent的位子
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.forward;
            run = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.back;
            run = true;
        }*/
        /*if (Input.GetKey(KeyCode.A))
        {
            n = 1;
            //transform.localPosition += movingSpeed * Time.deltaTime * Vector3.left;
            //run = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            n = 2;
            //transform.localPosition += movingSpeed * Time.deltaTime * Vector3.right;
            //run = true;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //跳起來建flag，碰到地板才flag拿掉
            rb.AddForce(JumpingForce * Time.deltaTime * Vector3.up);
        }

        animator.SetBool("Run", run);
        */
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

           

            if(Physics.Raycast(r, out raycastHit))
            {
                Destroy(raycastHit.collider.gameObject);
            }
        }*/

        //if (Input.GetMouseButtonDown(1))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //2D to 3D

           

        //    if (Physics.Raycast(ray, out raycastHit))
        //    {
        //        agent.SetDestination(raycastHit.point); 
        //    }
        //}

    }
    //bool IsGrounded()
    //{
    //    RaycastHit hit;
    //    float raycastDistance = 10;
    //    //Raycast to to the floor objects only
    //    int mask = 1 << LayerMask.NameToLayer("Ground");

    //    //Raycast downwards
    //    if (Physics.Raycast(transform.position, Vector3.down, out hit,
    //        raycastDistance, mask))
    //    {
    //        return true;
    //    }
    //    return false;
    //}
    float yRotation = 0;
    Quaternion rotation1 = Quaternion.Euler(0, 0, 0);
    Quaternion rotation2 = Quaternion.Euler(0, -90, 0);
    Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
    float degree = 0;
    void move()
    {
        //Jump
        //DownfallSpeed.y += gravity * Time.deltaTime;
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        //if (isGrounded && DownfallSpeed.y < 0)
        //{
        //    DownfallSpeed.y = 0f;
        //}
        // bool player_jump = Input.GetButtonDown("Jump");
        run = true;
        /*transform.localPosition += movingSpeed * Time.deltaTime * Vector3.forward;
        if (transform.rotation == Quaternion.Euler(0, 90, 0))
        {
            transform.position += movingSpeed * Time.deltaTime * Vector3.right;
        }
        else if (transform.rotation == Quaternion.Euler(0, -90, 0))
        {
            transform.position += movingSpeed * Time.deltaTime * Vector3.left;
        }
        else if(transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.forward;
        }else if(transform.rotation == Quaternion.Euler(0, 180, 0) || transform.rotation == Quaternion.Euler(0, -180, 0))
        {
            transform.position += movingSpeed * Time.deltaTime * Vector3.back;
        }*/
        transform.position += movingSpeed * Time.deltaTime * transform.forward;
        //rb.velocity = transform.forward * Time.deltaTime * movingSpeed;
       
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 
            //transform.rotation = Quaternion.Slerp(_sphereOriginRotation, rotation2, 1f);
            degree -= 90;
        targetRotation = Quaternion.Euler(0, degree, 0);
        float progress = 0f;
        float speed = 0.5f;

        while (progress < 1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, progress);

            progress += Time.deltaTime * speed;
            if (progress >= 1f)
            {
                transform.rotation = targetRotation;
                break;
            }

        }
                //        transform.rotation = rotation2;

                //yRotation -= 90;
                /*float a = Quaternion.Angle(rotation1, rotation2);
                float duration = (float)(a / 0.1) ;
                //transform.rotation = Quaternion.Euler(0, yRotation, 0);
                //float startTime = Time.deltaTime;
                //float endTime = startTime + duration;
                //transform.rotation = rotation1;
                float t = 0f;
                while (t < duration)
                {
                    transform.rotation = Quaternion.Slerp(rotation1, rotation2, t / duration);

                    t += Time.deltaTime;
                }
                //  transform.rotation = rotation2;
                //transform.Rotate(0.0f, -90.0f, 0.0f);
                */
            }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //yRotation += 90;
            //transform.rotation = Quaternion.Euler(0, yRotation, 0);
            transform.Rotate(0.0f, 90.0f, 0.0f);
            


        }
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(JumpingForce * Time.deltaTime * Vector3.up);
        }
        //    if (player_jump && IsGrounded())
        //{
        //    Debug.Log("jump");
        //    //跳起來建flag，碰到地板才flag拿掉
        //    rb.AddForce(JumpingForce * Time.deltaTime * Vector3.up);
        //}

        animator.SetBool("Run", run);
    }
    

       
}

