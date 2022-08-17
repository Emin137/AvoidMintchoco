using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Land : MonoBehaviour
{
    private static Land instance;
    public static Land Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<Land>();
            return instance;
        }
    }

    public static int currentScore;
    public static int coin;
    public float level;
    [SerializeField] Text scoreText;
    [SerializeField] Text coinText;
    
    void Start()
    {
        currentScore = 0;
        coin = 0;
        level = 1;
        scoreText.text = "Score" + currentScore;
        coinText.text = coin.ToString();
    }
    public void HandleScore()
    {
        currentScore++;
        level = 1 + (currentScore / 30);
        scoreText.text = "Score" + currentScore;
    }

    public void HandleCoin(int coinAdd)
    {
        coin += coinAdd;
        coinText.text = coin.ToString();
    }
}
