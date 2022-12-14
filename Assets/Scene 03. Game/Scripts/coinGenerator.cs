using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    private static CoinGenerator instance;
    public static CoinGenerator Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<CoinGenerator>();
            return instance;
        }
    }
    public float coinCreateTime;
    float mCreatTime = 0;
    float mTotalTIme = 0;

    float mNextCreateInterval;

    int mPhase = 1;

    public GameObject coin;
    private void Start()
    {
        coinCreateTime = 0.82f;
        mNextCreateInterval = coinCreateTime;
    }
    private void Update()
    {
        mTotalTIme += Time.deltaTime;
        mCreatTime += Time.deltaTime;
        if (mCreatTime > mNextCreateInterval)
        {
            mCreatTime = 0;
            mNextCreateInterval = coinCreateTime - (0.005f * mTotalTIme);
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
        float x = Random.Range(-2.5f, 2.5f);
        createObject(coin, new Vector3(x, y, 0), Quaternion.identity);
    }

    private GameObject createObject(GameObject original, Vector3 position, Quaternion rotation)
    {
        return (GameObject)Instantiate(original, position, rotation);
    }
}
