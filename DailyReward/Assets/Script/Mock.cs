using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mock : MonoBehaviour
{
    public int point;
    Text pointText;
    // Start is called before the first frame update
    void Start()
    {
        //pointText = GameObject.Find("Point").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddStress()
    {
        point += 1;
        //pointText.text = point.ToString();
    }

}
