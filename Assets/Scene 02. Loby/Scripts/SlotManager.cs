using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlotManager : MonoBehaviour
{
    public GameObject slotObject;
    public Image[] images;
    public Sprite[] sprites;
    public Text text;
    public int rulletNum;
    List<string> list = new List<string>();

    private void Start()
    {
        int N = Random.Range(0, 3);
        switch (N)
        {
            case 0: // ����ġ ȹ�淮 ����
                images[0].sprite = sprites[0];
                images[1].sprite = sprites[1];
                images[2].sprite = sprites[2];
                images[3].sprite = sprites[0];
                list.Add("����ġ ȹ�淮 ����");
                list.Add("����� ����");
                list.Add("�̵��ӵ� ����");
                break;
            case 1: // ����� ����
                images[0].sprite = sprites[1];
                images[1].sprite = sprites[2];
                images[2].sprite = sprites[0];
                images[3].sprite = sprites[1];
                list.Add("����� ����");
                list.Add("�̵��ӵ� ����");
                list.Add("����ġ ȹ�淮 ����");
                break;
            case 2: // �̵��ӵ� ����
                images[0].sprite = sprites[2];
                images[1].sprite = sprites[0];
                images[2].sprite = sprites[1];
                images[3].sprite = sprites[2];
                list.Add("�̵��ӵ� ����");
                list.Add("����ġ ȹ�淮 ����");
                list.Add("����� ����");
                break;
        }
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
                    text.text = list[0];
                    break;
                case 2:
                    text.text = list[1];
                    break;
                case 4:
                    text.text = list[2];
                    break;
                case 6:
                    text.text = list[0];
                    count = 0;
                    break;
            }

            yield return new WaitForSeconds(0.02f);
        }
    }
}
