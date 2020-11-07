using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniJSON;

public class Connection : MonoBehaviour
{
    string api1 = "https://jphacks-e2007.azurewebsites.net/api/tweets-analysis/";
    string api2 = "https://jphacks-e2007.azurewebsites.net/api/counter/";
    string twitterID;
    //string keyTA = "";
    string keyWR = "/weekly-reports";
    string keyRR = "/recently-reports?num=20";
    string keyIC = "/increment?code=d14TkuL64BPbGJNAu/4CR3Y8N7dsiLq5fFQ2YzhgKalkmx772NMu9A==";
    string testApi = "https://jphacks-e2007.azurewebsites.net/api/counter/isbsttk/increment?code=d14TkuL64BPbGJNAu/4CR3Y8N7dsiLq5fFQ2YzhgKalkmx772NMu9A==";
    [SerializeField] Text text;
    // Start is called before the first frame update
    void Start()
    {
        twitterID = "isbsttk";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    private IEnumerator Connect()
    {
        var www = new WWW(testApi);
        yield return www;
        var jsonDict = Json.Deserialize(www.text) as Dictionary<string, object>;
        string jsonstr = JsonUtility.ToJson(jsonDict);
        //Debug.Log(jsonDict["created_at"]);
        Debug.Log(jsonstr);
        text.text = jsonstr;
    }

    public void Test()
    {
        StartCoroutine("Connect");
    }
}
