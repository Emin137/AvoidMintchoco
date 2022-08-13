using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour
{
    private float gravity;
    private float mVelocity = 0f;

    private void Start()
    {
        gravity = 1.0f;
    }
    void Update()
    {
        Vector3 current = this.transform.position;

        mVelocity += gravity * Time.deltaTime * Land.Instance.level;

        current.y -= mVelocity * Time.deltaTime;
        this.transform.position = current;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Land.Instance.HandleCoin();
        }
        Destroy(this.gameObject);
    }
}
