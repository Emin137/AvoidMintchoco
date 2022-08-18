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
        Debug.Log("Application.Quit()를 호출합니다.");
        Application.Quit();
    }
    private void Loby()
    {
        Time.timeScale = 1f;
        ScoreManager.AddScore(new ScoreData(Land.Instance.coin, Land.Instance.currentScore));
        PlayerManager.GetPlayerList().Clear();
        SceneManager.LoadScene("Scene02. Loby");
    }
}
