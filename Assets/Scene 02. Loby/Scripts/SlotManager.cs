using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    public GameObject slotObject; 
    public Image[] images;
    public Text text;
    public int rulletRoundNum;
    public int objectNum;
    public bool lastRullet;
    public SkillData.SkillType skillType;
    List<string> listSkillName = new List<string>();

    public void Awake()
    {
        Queue<SkillData> skillDataQueue = new Queue<SkillData>(SkillManager.GetSkillStack(skillType));
        List<SkillData> skillDataList = new List<SkillData>();
        int N = Random.Range(0, objectNum + 1);
        for (int i = 0; i < N; i++)
            skillDataQueue.Enqueue(skillDataQueue.Dequeue());
        skillDataList = new List<SkillData>(skillDataQueue);
        for (int i = 0; i < skillDataQueue.Count; i++)
        {
            images[i + 1].sprite = skillDataList[i].skillSprite;
            listSkillName.Add(skillDataList[i].skillName);
        }
        images[0].sprite = skillDataList[0].skillSprite;
        StartCoroutine(StartSlot());
    }

    IEnumerator StartSlot()
    {
        int count = 0;
        for (int i = 0; i < (objectNum * rulletRoundNum)*2; i++)
        {
            slotObject.transform.localPosition -= new Vector3(0, 40f, 0);
            if(slotObject.transform.localPosition.y < 0)
            {
                slotObject.transform.localPosition += new Vector3(0, 80f*objectNum, 0);
            }
            count++;
            switch (count)
            {
                case 1:
                    text.text = listSkillName[0];
                    break;
                case 2:
                    text.text = listSkillName[1];
                    break;
                case 4:
                    text.text = listSkillName[2];
                    break;
                case 6:
                    text.text = listSkillName[0];
                    count = 0;
                    break;
            }
            yield return new WaitForSeconds(0.02f);
        }
        if (lastRullet)
        {
            UIManager.Instance.SetActiveStartButton();
            UIManager.Instance.SetActiveSlotAgainButton();
        }
    }
}
