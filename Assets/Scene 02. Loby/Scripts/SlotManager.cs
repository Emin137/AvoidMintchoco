using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    public GameObject slotObject; 
    public Image[] images;
    public Sprite[] sprites;
    public Text text;
    public int rulletRoundNum;
    public bool lastRullet;
    public string[] skillCode;
    List<string> list = new List<string>();
    


    private void Awake()
    {
        int N = Random.Range(0, 3);
        switch (N)
        {
            case 0: // index 0
                images[0].sprite = SkillManager.GetSkill(skillCode[0]).skillSprite;
                images[1].sprite = SkillManager.GetSkill(skillCode[1]).skillSprite;
                images[2].sprite = SkillManager.GetSkill(skillCode[2]).skillSprite;
                images[3].sprite = SkillManager.GetSkill(skillCode[0]).skillSprite;
                list.Add(SkillManager.GetSkill(skillCode[0]).skillName);
                list.Add(SkillManager.GetSkill(skillCode[1]).skillName);
                list.Add(SkillManager.GetSkill(skillCode[2]).skillName);
                break;
            case 1: // index 1
                images[0].sprite = SkillManager.GetSkill(skillCode[1]).skillSprite;
                images[1].sprite = SkillManager.GetSkill(skillCode[2]).skillSprite;
                images[2].sprite = SkillManager.GetSkill(skillCode[0]).skillSprite;
                images[3].sprite = SkillManager.GetSkill(skillCode[1]).skillSprite;
                list.Add(SkillManager.GetSkill(skillCode[1]).skillName);
                list.Add(SkillManager.GetSkill(skillCode[2]).skillName);
                list.Add(SkillManager.GetSkill(skillCode[0]).skillName);
                break;
            case 2: // index 2
                images[0].sprite = SkillManager.GetSkill(skillCode[2]).skillSprite;
                images[1].sprite = SkillManager.GetSkill(skillCode[0]).skillSprite;
                images[2].sprite = SkillManager.GetSkill(skillCode[1]).skillSprite;
                images[3].sprite = SkillManager.GetSkill(skillCode[2]).skillSprite;
                list.Add(SkillManager.GetSkill(skillCode[2]).skillName);
                list.Add(SkillManager.GetSkill(skillCode[0]).skillName);
                list.Add(SkillManager.GetSkill(skillCode[1]).skillName);
                break;
        }
        StartCoroutine(StartSlot());
    }

    IEnumerator StartSlot()
    {
        int count = 0;
        for (int i = 0; i < (3*rulletRoundNum)*2; i++)
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
        if (lastRullet)
            UIManager.Instance.SetActiveStartButton();
    }
}
