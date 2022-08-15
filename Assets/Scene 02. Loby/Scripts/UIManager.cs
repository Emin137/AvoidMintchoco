using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button gameReadyButton;
    [SerializeField] private Button gameStartButton;
    [SerializeField] private GameObject panelGameObject;
    [SerializeField] private GameObject panelLoby;

    private void Awake()
    {
        gameReadyButton.onClick.AddListener(SetActivePanel);
        gameStartButton.onClick.AddListener(SceneTrans);
    }

    private void SetActivePanel()
    {
        panelGameObject.SetActive(true);
        panelLoby.SetActive(false);
    }

    private void SceneTrans()
    {
        SceneManager.LoadScene("Scene03. Game");
    }
}
