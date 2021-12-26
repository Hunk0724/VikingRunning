using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class SwitchToPauseList : MonoBehaviour
{
    public int SceneIndexDestination = 1;

    public void OnPointerClick(PointerEventData e)
    {
        //get the current scene
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("current scene name = " + scene.name + "and scene index = " + scene.buildIndex);

        //load a new scene
        SceneManager.LoadScene(SceneIndexDestination);
    }
}