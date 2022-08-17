using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DieMenu : MonoBehaviour
{
    [SerializeField] Button lobyButton;
    [SerializeField] Button quitButton;
    [SerializeField] Text coinText;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        quitButton.onClick.AddListener(Quit);
        lobyButton.onClick.AddListener(Loby);
    }
    private void Update()
    {
        coinText.text = Land.Instance.coin.ToString();
        scoreText.text = "Score" + Land.Instance.currentScore;
    }
    private void Quit()
    {
        Debug.Log("¹Ì±¸Çö");
    }
    private void Loby()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene02. Loby");
    }
}
