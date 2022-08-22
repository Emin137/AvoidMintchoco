using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private static List<SkillData> skillDataList = new List<SkillData>();
    private static List<SkillData> resultSkillList = new List<SkillData>();

    public static void AddSkill(SkillData skillData)
    {
        skillDataList.Add(skillData);
    }    

    public static void AddResultSkill(SkillData skilldata)
    {
        resultSkillList.Add(skilldata);
    }

    public static List<SkillData> GetResultSkill()
    {
        return resultSkillList;
    }

    public static SkillData GetSkill(string code)
    {
        for (int i = 0; i < skillDataList.Count; i++)
        {
            if (skillDataList[i].skillCode == code)
                return skillDataList[i];
        }
        return null;
    }

    public static Queue<SkillData> GetSkillStack(SkillData.SkillType skillType)
    {
        Queue<SkillData> skillDataQueue = new Queue<SkillData>();
        for (int i = 0; i < skillDataList.Count; i++)
        {
            if (skillDataList[i].skillType==skillType)
                skillDataQueue.Enqueue(skillDataList[i]);
        }
        return skillDataQueue;
    }


    private void Awake()
    {
        SkillManager.AddSkill(new SkillData("00", "���ڱ���", "�÷��̾�� ��ȣ���� �����Ǿ� ������ 1ȸ ��ȣ�մϴ�.", SkillData.SkillType.Passive));
        SkillManager.AddSkill(new SkillData("01", "�̵��ӵ� ����", "�÷��̾��� �̵��ӵ��� 1.5�� �����մϴ�.", SkillData.SkillType.Passive));
        SkillManager.AddSkill(new SkillData("02", "���� ����� ��!", "���� ȹ�淮�� 2�� �����մϴ�.", SkillData.SkillType.Passive));
        SkillManager.AddSkill(new SkillData("03", "����", "ª�� �Ÿ��� �����̵��մϴ�.", SkillData.SkillType.Active));
        SkillManager.AddSkill(new SkillData("04", "������!", "�÷��̾ 2�� ���� ������ �� ������ �������°� �˴ϴ�.", SkillData.SkillType.Active));
        SkillManager.AddSkill(new SkillData("05", "�ΰŽ���", "���� ���������ִ� ���� ������ Ÿ�뽺 �մϴ�.", SkillData.SkillType.Active));
        SkillManager.AddSkill(new SkillData("06", "������ ����", "��Ʈ������ �����ֱⰡ �����մϴ�.", SkillData.SkillType.Debuff));
        SkillManager.AddSkill(new SkillData("07", "������ ��", "��Ʈ������ ũ�Ⱑ ����մϴ�.", SkillData.SkillType.Debuff));
        SkillManager.AddSkill(new SkillData("08", "���� ���ڴ�", "���� �����ֱⰡ �����ϸ� ȹ�淮�� 2�� �����մϴ�..", SkillData.SkillType.Debuff));
    }


}
