using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartManager : MonoBehaviour
{
    public GameObject loginPanel;
    public Button gameStartButton;
    public Button loginButton;
    public InputField inputField;
    public static string name;
    public static int coin;
    public GameObject music;

    private void Awake()
    {
        gameStartButton.onClick.AddListener(ShowLoginPanel);
        loginButton.onClick.AddListener(Login);
        DontDestroyOnLoad(music);
        
    }

    private void ShowLoginPanel()
    {
        loginPanel.SetActive(true);
    }

    private void Login()
    {
        if(PlayerPrefs.HasKey(inputField.text))
             coin = PlayerPrefs.GetInt(inputField.text);
        else
            PlayerPrefs.SetInt(inputField.text, 0);
        name= inputField.text;
        SceneManager.LoadScene("Scene02. Loby");
    }

    public static void SetUserCoin(int num)
    {
        PlayerPrefs.SetInt(name, num);
    }

    public static int GetUserCoin()
    {
       return PlayerPrefs.GetInt(name);
    }
}
