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
        SkillManager.AddSkill(new SkillData("00", "원코국룰", "플레이어에게 보호막이 생성되어 공격을 1회 보호합니다.", SkillData.SkillType.Passive));
        SkillManager.AddSkill(new SkillData("01", "이동속도 증가", "플레이어의 이동속도가 1.5배 증가합니다.", SkillData.SkillType.Passive));
        SkillManager.AddSkill(new SkillData("02", "묻고 더블로 가!", "코인 획득량이 2배 증가합니다.", SkillData.SkillType.Passive));
        SkillManager.AddSkill(new SkillData("03", "점멸", "짧은 거리를 순간이동합니다.", SkillData.SkillType.Active));
        SkillManager.AddSkill(new SkillData("04", "얼음땡!", "플레이어가 2초 동안 움직일 수 없으며 무적상태가 됩니다.", SkillData.SkillType.Active));
        SkillManager.AddSkill(new SkillData("05", "핑거스냅", "현재 떨어지고있는 똥의 반절을 타노스 합니다.", SkillData.SkillType.Active));
        SkillManager.AddSkill(new SkillData("06", "무수한 민초", "민트초코의 생성주기가 증가합니다.", SkillData.SkillType.Debuff));
        SkillManager.AddSkill(new SkillData("07", "사이즈 업", "민트초코의 크기가 상승합니다.", SkillData.SkillType.Debuff));
        SkillManager.AddSkill(new SkillData("08", "나는 부자다", "코인 생성주기가 증가하며 획득량이 2배 증가합니다..", SkillData.SkillType.Debuff));
    }


}
