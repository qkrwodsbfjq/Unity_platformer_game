//==========================================
// writer : 손지.
// file : ItemDatabase.cs.
// content : 아이템 속성 정의.
// discript : 아이템 생성 시 사용할 슈퍼클래스 소스. ItemDatabase 디버깅을 위해 무력화.
//==========================================
/*
using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
    public string itemName;         // 아이템 이름
    public int itemID;              // 아이템 고유번호
    public string itemDes;          // 아이템 설명
    public Texture2D itemIcon;      // 아이템 아이콘(2D)
    public int itemPower;           // 아이템의 공격력
    public int itemDefense;         // 아이템의 방어력
    public ItemType itemType;       // 아이템의 속성 설정

    //임시로 열거형으로 작성. 향후 아이템별 객체를 따로 굴릴 예정.
    public enum ItemType            // 아이템의 속성 설정에 대한 갯수
    {
        Weapon,                     // 무기류 (검, 방패, 창 등 해당)
        Costume,                    // 옷류   (상의, 하의, 모자 등 해당)
        Hidden,                     // 퀘스트 아이템류
        Use                         // 소모품류
    }

    public Item(string name, int id, string desc, int power, int defense, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemDes = desc;
        itemPower = power;

        itemIcon = Resources.Load<Texture2D>("ItemIcons/" + name);

        itemDefense = defense;
        itemType = type;
    }
}
*/
