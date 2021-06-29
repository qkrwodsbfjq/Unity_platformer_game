//==========================================
// writer : 손지.
// file : ItemDatabase.cs.
// content : 아이템 관리 소스.
// discript : 아이템 생성 시 본 소스를 통해 생성 및 수정 가능.
//==========================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> database = new List<Item>();
    private JsonData itemData;


    void Start()
    {
        //Item item = new Item(0, "Ball", 5);
        //database.Add(item);
        //Debug.Log(database[0].Title);
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();

        Debug.Log(database[1].Title);
    }

    void ConstructItemDatabase()
    {
        for(int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), (int)itemData[i]["value"]));
        }
    }
}

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }

    public Item(int id, string title, int value)
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
    }
}
