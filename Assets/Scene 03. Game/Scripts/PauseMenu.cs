using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] Button resumeButton;
    [SerializeField] Button LobyButton;
    public static bool GameIsPaused = false;

    public GameObject pauseMenu;

    // Update is called once per frame
    private void Awake()
    {
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        LobyButton.onClick.AddListener(Loby);
    }

    private void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    private void Loby()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene02. Loby");
    }
}
