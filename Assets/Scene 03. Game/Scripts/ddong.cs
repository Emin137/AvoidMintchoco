using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ddong : MonoBehaviour
{
    private float gravity = 1.0f;
    private float mVelocity = 0f;

    void Update()
    {
        Vector3 current = this.transform.position;

        mVelocity += gravity * Time.deltaTime;

        current.y -= mVelocity * Time.deltaTime;
        this.transform.position = current;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log("die");
        }
        if (collision.name == "Land")
        {
            LandScore.Instance.HandleScore();
        }
        Destroy(this.gameObject);
    }
}
