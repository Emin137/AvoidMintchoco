using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandScore : MonoBehaviour
{
    private static LandScore instance;
    public static LandScore Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<LandScore>();
            return instance;
        }
    }

    public static int currentScore;
    public Text scoreText;
    void Start()
    {
        currentScore = 1;
    }
    public void HandleScore()
    {
        currentScore++;
        scoreText.text = "Score" + currentScore;
    }
}
