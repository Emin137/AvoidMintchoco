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
        SkillManager.AddSkill(new SkillData("00", "원코", "플레이어에게 보호막이 생성되어 공격을 1회 막습니다.", SkillData.SkillType.Passive));
        SkillManager.AddSkill(new SkillData("01", "이동속도 증가", "플레이어의 이동속도가 1.5배 빨라집니다.", SkillData.SkillType.Passive));
        SkillManager.AddSkill(new SkillData("02", "묻고 더블로 가", "코인 획득량이 2배 증가됩니다.", SkillData.SkillType.Passive));
        SkillManager.AddSkill(new SkillData("03", "점멸", "짧은 거리를 순간이동합니다.", SkillData.SkillType.Active));
        SkillManager.AddSkill(new SkillData("04", "존야", "플레이어가 2초 동안 움직일 수 없으며 무적상태가 됩니다.", SkillData.SkillType.Active));
        SkillManager.AddSkill(new SkillData("05", "핑거스냅", "스테이지에 있는 똥의 1/2를 타노스 합니다.", SkillData.SkillType.Active));
        SkillManager.AddSkill(new SkillData("06", "무수한 똥", "떨어지는 똥의 생성주기가 1.5배 빨라집니다.", SkillData.SkillType.Debuff));
        SkillManager.AddSkill(new SkillData("07", "거대한 똥", "떨어지는 똥의 크기가 1.5배 커집니다.", SkillData.SkillType.Debuff));
        SkillManager.AddSkill(new SkillData("08", "엄청난 똥", "일정시간마다 엄청난 똥이 떨어집니다.", SkillData.SkillType.Debuff));
    }


}
