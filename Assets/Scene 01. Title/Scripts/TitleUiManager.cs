using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUiManager : MonoBehaviour
{
    [SerializeField] Button gameReadyButton;
    [SerializeField] Button settingButton;
    [SerializeField] Button soundButton;
    [SerializeField] Button closeButton;
    [SerializeField] Button endButton;

    [SerializeField] GameObject SettingPanel;

    private void Awake()
    {
        gameReadyButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Scene02. Loby");
        });

        settingButton.onClick.AddListener(() =>
        {
                SettingPanel.SetActive(true);
        });
        soundButton.onClick.AddListener(() =>
        {

        });
        closeButton.onClick.AddListener(() =>
        {
            SettingPanel.SetActive(false);
        });
        endButton.onClick.AddListener(() =>
        {
            
        });
    }
}
