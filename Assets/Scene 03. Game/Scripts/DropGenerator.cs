using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGenerator : MonoBehaviour
{
    private static DropGenerator instance;
    public static DropGenerator Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<DropGenerator>();
            return instance;
        }
    }
    public float ddongCreatTime;
    float mCreatTime = 0;
    float mTotalTIme = 0;

    float mNextCreateInterval;

    int mPhase = 1;

    public GameObject mDrop;
    public GameObject BigmDrop;
    private PlayerData PlayerData;

    private void Start()
    {
        ddongCreatTime = 0.3f;
        mNextCreateInterval = ddongCreatTime;
        for (int i = 0; i < 3; i++)
        {
            if (PlayerManager.GetPlayerList()[i].nowChoose)
                PlayerData = PlayerManager.GetPlayerList()[i];
        }
        mDrop = Resources.Load<GameObject>($"Scene 03. Game/Player{PlayerData.playerCode}/Drop");
        BigmDrop = Resources.Load<GameObject>($"Scene 03. Game/Player{PlayerData.playerCode}/BigDrop");
    }
    private void Update()
    {
        mTotalTIme += Time.deltaTime;
        mCreatTime += Time.deltaTime;
        if (mCreatTime > mNextCreateInterval)
        {
            mCreatTime = 0;
            mNextCreateInterval = ddongCreatTime - (0.005f * mTotalTIme);
            if (mNextCreateInterval < 0.005f)
            {
                mNextCreateInterval = 0.005f;
            }

            for (int i = 0; i < mPhase; i++)
            {
                creatDdong(8f + i * 0.2f);
            }

        }

        if (mTotalTIme >= 10f)
        {
            mTotalTIme = 0;
            mPhase++;
        }
    }

    private void creatDdong(float y)
    {
        if (PlayerController.Instance.bigDDong == false)
        {
            float x = Random.Range(-2.5f, 2.5f);
            createObject(mDrop, new Vector3(x, y, 0), Quaternion.identity);
        }
        if (PlayerController.Instance.bigDDong == true)
        {
            float x = Random.Range(-2.5f, 2.5f);
            createObject(BigmDrop, new Vector3(x, y, 0), Quaternion.identity);
        }
    }

    private GameObject createObject(GameObject original, Vector3 position, Quaternion rotation)
    {
        return (GameObject)Instantiate(original, position, rotation);
    }
}
