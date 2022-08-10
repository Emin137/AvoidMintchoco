using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button gameStartButton;
    [SerializeField] private GameObject panelGameObject;

    private void Awake()
    {
        gameStartButton.onClick.AddListener(SetActivePanel);
    }

    private void SetActivePanel()
    {
        panelGameObject.SetActive(true);
    }
}
