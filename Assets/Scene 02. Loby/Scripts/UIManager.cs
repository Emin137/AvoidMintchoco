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
    public GameObject panelGameReady;
    public GameObject panelLoby;
    public GameObject panelSet;
    public GameObject panelRank;
    public GameObject panelToolTip;
    public Text skillNameText;
    public Text skillDescriptionText;
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
        slotAgainButton.onClick.AddListener(SlotAgain);
        gameStartButton.interactable = false;
        slotAgainButton.interactable = false;
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
}
