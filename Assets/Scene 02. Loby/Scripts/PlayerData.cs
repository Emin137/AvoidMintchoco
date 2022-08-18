using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
   
    public string playerCode; // 고유 코드값
    public string playerName; // 이름
    public Sprite playerSprite; // 아이콘
    public Sprite dropSprite; // 아이콘
    public bool nowChoose;


    // 아이템 생성자
    public PlayerData(string code, string name)
    {
        playerCode = code;
        playerName = name;
        playerSprite = Resources.Load<Sprite>($"Scene 03. Game/Sprites/Player{code}/Player");
        dropSprite = Resources.Load<Sprite>($"Scene 03. Game/Sprites/Player{code}/Drop");
        nowChoose = false;
    }
}
