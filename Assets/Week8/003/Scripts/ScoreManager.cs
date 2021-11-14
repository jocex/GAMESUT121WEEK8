using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score;
     public TMP_Text scoreText;

     public static void AddToScore(){
        score+= 1;
    }

    public static void MinusToScore(){
        score-= 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text="score: " + score;
    }
}
