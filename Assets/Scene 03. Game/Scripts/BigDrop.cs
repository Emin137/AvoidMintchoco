using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigDrop : MonoBehaviour
{
    private float gravity;
    private float mVelocity = 0f;
    public static bool GameIsPaused = false;

    private void Start()
    {
        gravity = 0.7f;
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
        if (collision.name != "coin(Clone)")
        {
            if (collision.name == "Land")
            {
                Land.Instance.HandleScore();
            }
            Destroy(this.gameObject);
        }
    }
}
