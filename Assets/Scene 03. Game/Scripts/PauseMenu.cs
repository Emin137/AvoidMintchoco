using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private static PauseMenu instance;
    public static PauseMenu Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<PauseMenu>();
            return instance;
        }
    }
    [SerializeField] Button pauseButton;
    [SerializeField] Button resumeButton;
    [SerializeField] Button lobyButton;
    [SerializeField] Button quitButton;
    public static bool GameIsPaused = false;

    public GameObject pauseMenu;

    // Update is called once per frame
    private void Awake()
    {   
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        lobyButton.onClick.AddListener(Loby);
        quitButton.onClick.AddListener(Quit);
    }

    private void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    private void Loby()
    {
        Time.timeScale = 1f;
        PlayerController.Instance.ClearSkill();
        SceneManager.LoadScene("Scene02. Loby");
    }
    private void Quit()
    {
        Debug.Log("¹Ì±¸Çö");
    }
}
