using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private static List<SkillData> skillDataList = new List<SkillData>();

    public static void AddSkill(SkillData skillData)
    {
        skillDataList.Add(skillData);
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

    private void Awake()
    {
        SkillManager.AddSkill(new SkillData("00", "����", "�÷��̾�� ��ȣ���� �����Ǿ� ������ 1ȸ �����ϴ�.", SkillData.SkillType.Passive));
        SkillManager.AddSkill(new SkillData("01", "�̵��ӵ� ����", "�÷��̾��� �̵��ӵ��� 1.5�� �������ϴ�.", SkillData.SkillType.Passive));
        SkillManager.AddSkill(new SkillData("02", "���� ����� ��", "���� ȹ�淮�� 2�� �����˴ϴ�.", SkillData.SkillType.Passive));
        SkillManager.AddSkill(new SkillData("03", "����", "ª�� �Ÿ��� �����̵��մϴ�.", SkillData.SkillType.Active));
        SkillManager.AddSkill(new SkillData("04", "����", "�÷��̾ 2�� ���� ������ �� ������ �������°� �˴ϴ�.", SkillData.SkillType.Active));
        SkillManager.AddSkill(new SkillData("05", "�ΰŽ���", "���������� �ִ� ���� 1/2�� Ÿ�뽺 �մϴ�.", SkillData.SkillType.Active));
        SkillManager.AddSkill(new SkillData("06", "������ ��", "�������� ���� �����ֱⰡ 1.5�� �������ϴ�.", SkillData.SkillType.Debuff));
        SkillManager.AddSkill(new SkillData("07", "�Ŵ��� ��", "�������� ���� ũ�Ⱑ 1.5�� Ŀ���ϴ�.", SkillData.SkillType.Debuff));
        SkillManager.AddSkill(new SkillData("08", "��û�� ��", "�����ð����� ��û�� ���� �������ϴ�.", SkillData.SkillType.Debuff));
    }


}
