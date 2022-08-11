using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemID; // ������ ���� ID��
    public string itemName; // ������ �̸�
    public string itemDescription; // ������ ����
    public Sprite itemIcon; // �������� ������
    public ItemType itemType; // ������ Ÿ��

    public enum ItemType
    {
        Skill,
        Buff, 
        Debuff, 
        ETC 
    }

    // ������ ������
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
