using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    NewController playerMovement;
    dragonController dragonController;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<NewController>();
        dragonController = GameObject.FindObjectOfType<dragonController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            playerMovement.Die();
            dragonController.Attack();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
