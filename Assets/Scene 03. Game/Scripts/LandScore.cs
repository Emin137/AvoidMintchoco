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
    public float level;
    public Text scoreText;
    void Start()
    {
        currentScore = 0;
        level = 1;
        scoreText.text = "Score" + currentScore;
    }
    public void HandleScore()
    {
        currentScore++;
        level = 1 + (currentScore / 30);
        scoreText.text = "Score" + currentScore;
    }
}
