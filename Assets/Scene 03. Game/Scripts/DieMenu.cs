using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DieMenu : MonoBehaviour
{
    [SerializeField] Button lobyButton;
    [SerializeField] Button quitButton;
    private void Awake()
    {
        quitButton.onClick.AddListener(Quit);
        lobyButton.onClick.AddListener(Loby);
    }
    private void Quit()
    {
        Debug.Log("구현아직안함");
    }
    private void Loby()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene02. Loby");
    }
}
