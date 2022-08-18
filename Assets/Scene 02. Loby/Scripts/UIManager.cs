using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button gameReadyButton;
    public Button gameStartButton;
    public Button slotAgainButton;
    public Button setButton;
    public Button rankButton;
    public Button rankCloseButton;
    public Button setCloseButton;
    public GameObject panelGameReady;
    public GameObject panelLoby;
    public GameObject panelSet;
    public GameObject panelRank;
    public GameObject panelToolTip;
    public GameObject rankPanel;
    public GameObject panelChoosePlayer;
    public GameObject panelNeedChoose;
    public Text skillNameText;
    public Text skillDescriptionText;
    public Text coinNumText;
    private int coin = 0;
    private int count = 0;
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
        rankButton.onClick.AddListener(ShowPanelRank);
        rankCloseButton.onClick.AddListener(HidePanelRank);
        gameStartButton.onClick.AddListener(SceneTrans);
        slotAgainButton.onClick.AddListener(SlotAgain);
        setCloseButton.onClick.AddListener(HidePanelSet);
        gameStartButton.interactable = false;
        slotAgainButton.interactable = false;
        gameReadyButton.interactable = false;
        for (int i = 0; i < ScoreManager.GetScoreData().Count; i++)
        {
            coin += ScoreManager.GetScoreData()[i].coin;
        }
    }

    private void Update()
    {
        coinNumText.text = $"Coin : {coin}";
    }

    private void SetActivePanelGameReady()
    {
        panelGameReady.SetActive(true);
        panelLoby.SetActive(false);
        panelChoosePlayer.SetActive(false);
    }

    private void SetActivePanelSet()
    {
        panelSet.SetActive(true);
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

    public void SetActiveSlotAgainButton()
    {
        slotAgainButton.interactable = true;
    }

    public void SlotAgain()
    {
        gameStartButton.interactable = false;
        slotAgainButton.interactable = false;
    }

    public void ShowPanelToolTip(string name, string description)
    {
        panelToolTip.SetActive(true);
        skillNameText.text = name;
        skillDescriptionText.text = description;
    }

    public void HidePanelToolTip()
    {
        panelToolTip.SetActive(false);
    }

    public void ShowPanelRank()
    {
        panelRank.SetActive(true);
        panelLoby.SetActive(false);
    }

    public void HidePanelRank()
    {
        panelRank.SetActive(false);
        panelLoby.SetActive(true);
    }

    public void HidePanelSet()
    {
        panelSet.SetActive(false);
        panelLoby.SetActive(true);
    }
}
