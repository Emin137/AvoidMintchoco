using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] Button button;

    private void Awake()
    {
        button.onClick.AddListener(TransScene);
    }

    private void TransScene()
    {
        SceneManagerment.Instance.TransScene2();
    }
}
