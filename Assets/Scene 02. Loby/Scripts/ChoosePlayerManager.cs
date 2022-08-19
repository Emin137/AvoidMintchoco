using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayerManager : MonoBehaviour
{
    public Image playerImage;
    public Image dropImage;
    public Button chooseButton;
    public Button rightButton;
    public Button leftButton;
    public Text textPlayerName;
    private int numIndex = 1;
    public AudioSource audioSource;
    public AudioClip error;

    private void Awake()
    {
        playerImage.sprite = PlayerManager.GetPlayerList()[numIndex].playerSprite;
        dropImage.sprite = PlayerManager.GetPlayerList()[numIndex].dropSprite;
        textPlayerName.text = PlayerManager.GetPlayerList()[numIndex].playerName;
        chooseButton.interactable = true;
        rightButton.onClick.AddListener(Right);
        leftButton.onClick.AddListener(Left);
        chooseButton.onClick.AddListener(Choose);
    }

    private void Right()
    {
        numIndex++;
        if (numIndex > 2)
        {
            Debug.Log("더이상 오른쪽으로 넘어갈수업슴");
            audioSource.clip = error;
            audioSource.Play();
            numIndex--;
        }
        playerImage.sprite = PlayerManager.GetPlayerList()[numIndex].playerSprite;
        dropImage.sprite = PlayerManager.GetPlayerList()[numIndex].dropSprite;
        textPlayerName.text = PlayerManager.GetPlayerList()[numIndex].playerName;
        if (PlayerManager.GetPlayerList()[numIndex].nowChoose)
        {
            chooseButton.interactable = false;
        }
        else
            chooseButton.interactable = true;

    }

    private void Left()
    {
        numIndex--;
        if(numIndex<0)
        {
            Debug.Log("더이상 왼쪽으로 넘어갈수업슴");
            audioSource.clip = error;
            audioSource.Play();
            numIndex++;
        }
        playerImage.sprite = PlayerManager.GetPlayerList()[numIndex].playerSprite;
        dropImage.sprite = PlayerManager.GetPlayerList()[numIndex].dropSprite;
        textPlayerName.text = PlayerManager.GetPlayerList()[numIndex].playerName;
        if (PlayerManager.GetPlayerList()[numIndex].nowChoose)
        {
            chooseButton.interactable = false;
        }
        else
            chooseButton.interactable = true;

    }

    private void Choose()
    {
        for (int i = 0; i < PlayerManager.GetPlayerList().Count; i++)
        {
            PlayerManager.GetPlayerList()[i].nowChoose = false;
            if (i == numIndex)
                PlayerManager.GetPlayerList()[i].nowChoose = true;
        }
        chooseButton.interactable = false;
        UIManager.Instance.gameReadyButton.interactable = true;
    }

}
