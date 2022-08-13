using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlotManager : MonoBehaviour
{
    public GameObject slotObject;
    public Button slot;
    public Image[] images;
    public Text text;
    public int rulletNum;

    private void Awake()
    {
        slot.onClick.AddListener(SceneTrans);
    }

    private void Start()
    {
        int N = Random.Range(1, 3);
        if(N==1)
        {

        }   
        else if(N==2)
        {

        }
        else
        {

        }
        
       
        slot.interactable = false;
        StartCoroutine(StartSlot());
    }

    IEnumerator StartSlot()
    {
        int count = 0;
        for (int i = 0; i < (3*rulletNum)*2; i++)
        {
            slotObject.transform.localPosition -= new Vector3(0, 40f, 0);
            if(slotObject.transform.localPosition.y < 0)
            {
                slotObject.transform.localPosition += new Vector3(0, 240f, 0);
            }
            count++;
            switch (count)
            {
                case 1:
                    text.text = images[2].ToString();
                    break;
                case 2:
                    text.text = images[0].ToString();
                    break;
                case 4:
                    text.text = images[1].ToString();
                    break;
                case 6:
                    text.text = images[2].ToString();
                    count = 0;
                    break;
            }

            yield return new WaitForSeconds(0.02f);
        }
        slot.interactable = true;
    }

    private void SceneTrans()
    {
        SceneManager.LoadScene("Scene03. Game");
    }

}
