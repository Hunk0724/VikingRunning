using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class sensor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("trigger");

        Debug.Log(collider.transform.name);

        if(collider.transform.name == "viking")
        {
            Debug.Log("viking enter");
        }
    }
}
