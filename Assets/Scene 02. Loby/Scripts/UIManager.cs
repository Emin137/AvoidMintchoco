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
    public Button setCloseButton;
    public GameObject panelGameReady;
    public GameObject panelLoby;
    public GameObject panelSet;
    public GameObject panelToolTip;
    public GameObject panelChoosePlayer;
    public Text skillNameText;
    public Text skillDescriptionText;
    public Text coinNumText;
    public Text userNameText;
    public Toggle musicToggle;
    public Toggle soundToggle;
    public AudioSource audioSource;
    public AudioClip error;
    

    private int coin = 0;
    private int count = 0;
    private string name;
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
        gameStartButton.onClick.AddListener(SceneTrans);
        slotAgainButton.onClick.AddListener(SlotAgain);
        setCloseButton.onClick.AddListener(HidePanelSet);
        gameStartButton.interactable = false;
        slotAgainButton.interactable = false;
        gameReadyButton.interactable = false;
        name = GameStartManager.name;
        userNameText.text = name;
    }

    private void Update()
    {
        coin = PlayerPrefs.GetInt(name);
        coinNumText.text = $"Coin : {coin}";
        if (musicToggle.isOn)
            GameObject.FindObjectOfType<AudioManager>().GetComponent<AudioSource>().volume = 0.3f;
        else
            GameObject.FindObjectOfType<AudioManager>().GetComponent<AudioSource>().volume = 0;
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
        if(GameStartManager.GetUserCoin()>=30)
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

    public void HidePanelSet()
    {
        panelSet.SetActive(false);
        panelLoby.SetActive(true);
    }
}
