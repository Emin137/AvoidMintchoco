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
    public string skillCode; // ���� �ڵ尪
    public string skillName; // �̸�
    public string skillDescription; // ����
    public Sprite skillSprite; // ������
    public SkillType skillType;
    

    // ������ ������
    public SkillData(string code, string name, string desciption, SkillType type)
    {
        skillCode = code;
        skillName = name;
        skillDescription = desciption;
        skillSprite = Resources.Load<Sprite>($"Scene 02. Loby/Sprites/Skills/{skillCode}");
        skillType = type;
    }
    
}
