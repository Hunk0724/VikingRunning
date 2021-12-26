using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemController : MonoBehaviour
{
    //
    Animator animator;
    bool ifWalk = true, ifAttack = false;
    // Start is called before the first frame update
    void Start()
    {
       // 
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Walk", ifWalk);
        animator.SetBool("Attack", ifAttack);
    }

    public void Attack()
    {
       // 
        transform.localPosition += new Vector3(0f, 0f, 1f);
        ifWalk = false;
        ifAttack = true;
    }

}
