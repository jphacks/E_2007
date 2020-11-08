using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HomeScript : MonoBehaviour
{
    public int point;
    public int tweetPoint;
    Text pointText;
    int pointSum;
    public int rewardNum;
    [SerializeField] GameObject comment;
    [SerializeField] Text rewardText;
    [SerializeField] string[] rewards = new string[10];

    bool rewardOn = false;
    FaceAnim faceAnim;
    Connection connection;

    DateTime date;
    public int today;
    public int nowDay;

    void Start()
    {
        pointText = GameObject.Find("Point").GetComponent<Text>();
        today = PlayerPrefs.GetInt("today");
        StartCoroutine("CheckDate");
    }


    void Update()
    {
        
    }

    public void AddStress()
    {
        point += 1;
        pointText.text = point.ToString();
    }

    private IEnumerator CheckDate()
    {
        for (; ; )
        {
            date = DateTime.Now;
            nowDay = int.Parse(date.Year.ToString() + date.Month.ToString("D2") + date.Day.ToString("D2"));

            if (today != nowDay)
            {
                point = 0;
                today = nowDay;
                PlayerPrefs.SetInt("today", today);
            }

            if(date.Hour >= 19)
            {
                RewardHour();
            }
            else
            {
                PoseHour();
            }


            yield return new WaitForSeconds(10f);
        }
    }

    [Obsolete]
    void RewardHour()
    {
        //apiからツイートのポイントを取ってくる
        if (rewardOn == false)
        {
            tweetPoint = -1;
            connection.StartRR();

            if (tweetPoint == -1)
            {

            }
            else if(tweetPoint >= 0)
            {
                faceAnim.RewardTime();
                comment.SetActive(true);
            }
            rewardOn = true;

        }

        
        pointSum = point + tweetPoint;
        if (pointSum <= 20)
        {
            rewardNum = 0;
        }
        else if (pointSum <= 40)
        {
            rewardNum = 1;
        }
        else if (pointSum <= 60)
        {
            rewardNum = 2;
        }
        else if (pointSum <= 80)
        {
            rewardNum = 3;
        }
        else if (pointSum <= 100)
        {
            rewardNum = 4;
        }
        else if (pointSum <= 150)
        {
            rewardNum = 5;
        }
        else if (pointSum <= 200)
        {
            rewardNum = 6;
        }
        else if (pointSum <= 300)
        {
            rewardNum = 7;
        }
        else if (pointSum <= 500)
        {
            rewardNum = 8;
        }
        else
        {
            rewardNum = 9;
        }

        
        rewardText.text = $"今日も一日お疲れ様でした！\n自分へのご褒美に\n「{rewards[rewardNum]}」\nはどうですか？";
    }

    void PoseHour()
    {
        if (rewardOn == true)
        {
            faceAnim.EndRewardTime();
            comment.SetActive(false);
            rewardOn = false;
        }
    }
}
