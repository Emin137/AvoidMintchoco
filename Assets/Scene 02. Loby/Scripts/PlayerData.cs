using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
   
    public string playerCode; // ���� �ڵ尪
    public string playerName; // �̸�
    public Sprite playerSprite; // ������
    public Sprite dropSprite; // ������
    public bool nowChoose;


    // ������ ������
    public PlayerData(string code, string name)
    {
        playerCode = code;
        playerName = name;
        playerSprite = Resources.Load<Sprite>($"Scene 03. Game/Sprites/Player{code}/Player");
        dropSprite = Resources.Load<Sprite>($"Scene 03. Game/Sprites/Player{code}/Drop");
        nowChoose = false;
    }
}
