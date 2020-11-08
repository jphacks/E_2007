using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniJSON;

public class Connection : MonoBehaviour
{
    string api1 = "https://jphacks-e2007.azurewebsites.net/api/tweets-analysis/";
    string apiIC = "https://jphacks-e2007.azurewebsites.net/api/counter/";
    public string twitterID;
    //string keyTA = "";
    string keyWR = "/weekly-reports";
    string keyRR = "/recently-reports?num=20&code=7wUpc4AtzV6XJ64P7KBUPvqDkAOPUGFxzs1aLsda1FenIYFk7hVggg==";
    string keyIC = "/increment?code=d14TkuL64BPbGJNAu/4CR3Y8N7dsiLq5fFQ2YzhgKalkmx772NMu9A==";
    string APIIC = "https://jphacks-e2007.azurewebsites.net/api/counter/isbsttk/increment?code=d14TkuL64BPbGJNAu/4CR3Y8N7dsiLq5fFQ2YzhgKalkmx772NMu9A==";
    public int RRnum = 20;

    
    [SerializeField] Text text;
    [SerializeField] InputField input;
    HomeScript homeScript;

    // Start is called before the first frame update
    void Start()
    {
        twitterID = "sako_data";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRR()
    {
        StartCoroutine("RecentlyReports");
    }

    [System.Obsolete]
    private IEnumerator IncrementCounter()
    {
        var www = new WWW(APIIC);
        Debug.Log("www探してる");
        yield return www;
        Debug.Log("www帰ってきた");

        var json = (IDictionary)MiniJSON.Json.Deserialize(www.text);
        var reports = (IList)json["reports"]; //[]はIList
        var created_at0 = (IDictionary)reports[0];
        string created_at = (string)created_at0["created_at"]; //reportsのリストの0番目のcreated_atの値
        Debug.Log(created_at);

        var num0 = (IDictionary)reports[0];
        int num = int.Parse(num0["num"].ToString());
        Debug.Log(num);
    }

    [System.Obsolete]
    private IEnumerator RecentlyReports()
    {
        string APIRR = $"https://jphacks-e2007.azurewebsites.net/api/tweets-analysis/{twitterID}/recently-reports?num={RRnum}&code=7wUpc4AtzV6XJ64P7KBUPvqDkAOPUGFxzs1aLsda1FenIYFk7hVggg==";
        var www = new WWW(APIRR);
        yield return www;

        var json = (IDictionary)MiniJSON.Json.Deserialize(www.text);
        var reports = (IDictionary)json["reports"]; //{}はIDictionaty
        var neg = int.Parse(reports["negatives"].ToString());
        EndRR(neg);
        //Debug.Log(neg);
    }

    void EndRR(int point)
    {
        homeScript.tweetPoint = point * 10;
    }


    public void InputID()
    {
        twitterID = input.text;
    }






    /*private IEnumerator IncrementCounterTest()
    {
        var www = new WWW(testApi);
        Debug.Log("www探してる");
        yield return www;
        Debug.Log("www帰ってきた");

        JsonNode jsonNode = JsonNode.Parse(www.text);
        //string reports = jsonNode["reports"].Get<string>();
        string created_at = jsonNode["reports"][0]["created_at"].Get<string>();
        Debug.Log(created_at);
        //int num = int.Parse(jsonNode["reports"][0]["num"].Get<string>()); //castできない
        //Debug.Log(num);
    }*/
}
