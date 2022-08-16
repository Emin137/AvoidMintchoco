using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData
{
    public enum SkillType
    {
        Debuff,
        Passive,
        Active
    }
    public string skillCode; // 고유 코드값
    public string skillName; // 이름
    public string skillDescription; // 설명
    public Sprite skillSprite; // 아이콘
    public SkillType skillType;
    

    // 아이템 생성자
    public SkillData(string code, string name, string desciption, SkillType type)
    {
        skillCode = code;
        skillName = name;
        skillDescription = desciption;
        skillSprite = Resources.Load<Sprite>($"Scene 02. Loby/Sprites/Skills/{skillCode}");
        skillType = type;
    }
    
}
