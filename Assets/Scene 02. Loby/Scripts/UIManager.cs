using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button gameReadyButton;
    [SerializeField] private Button gameStartButton;
    [SerializeField] private Button setButton;
    [SerializeField] private Button rankButton;
    [SerializeField] private GameObject panelGameReady;
    [SerializeField] private GameObject panelLoby;
    [SerializeField] private GameObject panelSet;
    [SerializeField] private GameObject panelRank;
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        gameReadyButton.onClick.AddListener(SetActivePanelGameReady);
        setButton.onClick.AddListener(SetActivePanelSet);
        rankButton.onClick.AddListener(SetActivePanelRank);
        gameStartButton.onClick.AddListener(SceneTrans);
        gameStartButton.interactable = false;
    }

    private void SetActivePanelGameReady()
    {
        panelGameReady.SetActive(true);
        panelLoby.SetActive(false);
    }

    private void SetActivePanelSet()
    {
        panelSet.SetActive(true);
        panelLoby.SetActive(false);
    }

    private void SetActivePanelRank()
    {
        panelRank.SetActive(true);
        panelLoby.SetActive(false);
    }

    private void SceneTrans()
    {
        SceneManager.LoadScene("Scene03. Game");
    }

    public void SetActiveStartButton()
    {
        gameStartButton.interactable = true;
    }
}
