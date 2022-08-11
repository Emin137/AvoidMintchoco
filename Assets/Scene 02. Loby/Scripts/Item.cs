using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemID; // 아이템 고유 ID값
    public string itemName; // 아이템 이름
    public string itemDescription; // 아이템 설명
    public Sprite itemIcon; // 아이템의 아이콘
    public ItemType itemType; // 아이템 타입

    public enum ItemType
    {
        Skill,
        Buff, 
        Debuff, 
        ETC 
    }

    // 아이템 생성자
    public void AddItem(int id, string name, string desciption, ItemType type)
    {
        itemID = id;
        itemName = name;
        itemDescription = desciption;
        itemType = type;
        itemIcon = Resources.Load("Scene 02. Loby/Sprites" + id.ToString(), typeof(Sprite)) as Sprite;
    }

    private void Start()
    {
        List<Item> itemList = new List<Item>();
    }


}
