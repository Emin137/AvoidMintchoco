using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Button backButton;
    [SerializeField] Button readyButton;

    private void Awake()
    {
        backButton.onClick.AddListener(() =>
        {
            
        });
        readyButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Loby");
        });
    }
}
