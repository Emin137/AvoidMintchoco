using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerment : MonoBehaviour
{
    public static SceneManagerment Instance
    {
        get
        {
            return instance;
        }
    }
    private static SceneManagerment instance;

    private void Start()
    {
        if(instance!=null)
            DestroyImmediate(instance);
        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Scene1");
    }

    public void TransScene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void TransScene2()
    {
        SceneManager.LoadScene("Scene2");
    }
}
