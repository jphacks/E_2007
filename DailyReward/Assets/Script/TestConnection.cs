using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;
using System;

[Serializable]
public class Item
{
    public int id;
    public string name;
    public string description;
}

public class TestConnection : MonoBehaviour
{
    string itemJson = "{ \"id\": 100, \"name\": \"テストアイテム\", \"description\": \"説明だよ\" }";




    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, object> itemDic = Json.Deserialize(itemJson) as Dictionary<string, object>;
        Debug.Log("item id " + int.Parse(itemDic["id"].ToString()));
        Debug.Log("item name " + (string)itemDic["name"]);


        string json = Json.Serialize(itemDic);
        Debug.Log("Json str " + json);

        Item item = JsonUtility.FromJson<Item>(itemJson);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
