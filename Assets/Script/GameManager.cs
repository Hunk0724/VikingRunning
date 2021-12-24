using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static GameManager inst;
    
    public Text scoreText;

    public void IncreamentScore()
    {
        score++;
        scoreText.text = score.ToString();
        NewController.movingSpeed += (float)(GameManager.score * 0.001);
    }

    private void Awake()
    {
        inst = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
