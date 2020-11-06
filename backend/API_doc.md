# 更新情報
- 2020/11/06: RecentlyReports 実装しました。
- 2020/11/06: WeeklyReports 実装しました。
- 2020/11/06: TweetAnalysis の POST で返すツイートの量を最大で5個にしました。
- 2020/11/06: TweetAnalysis のレスポンスのデータが文字化け(Unicode)になっているのを解消しました。


# TweetsAnalysis
ツイッターのツイート内容を分析する API

https://jphacks-e2007.azurewebsites.net/api/tweets-analysis/{user_id}

**{user_id} をツイッターのユーザー id に置き換えてください**

## GET
ユーザーに対する分析済みのデータを取得する。

### Input
- user_id: ツイッターのユーザー id

### Return
```json
"reports": [
  {
    "text": "String" ツイート内容,
    "created_at": "YYYY/MM/DD HH:mm:ss" ツイートされた日時,
    "p_or_n": "negative" もしくは "positive"
  },
  ...
]
```

## POST
ユーザーのツイート内容を分析する。最大で前から 50 ツイートまで取得して更新する。

### Input
- user_id: ツイッターのユーザー id

### Return
- ツイートの情報。最大で5つ。
```json
"reports": [
  {
    "text": "String" ツイート内容,
    "created_at": "YYYY/MM/DD HH:mm:ss" ツイートされた日時,
    "p_or_n": "negative" もしくは "positive"
  },
  ...
]
```

# WeeklyReports
一週間のレポートを取得する API

https://jphacks-e2007.azurewebsites.net/api/tweets-analysis/{user_id}/weekly-reports

**{user_id} をツイッターのユーザー id に置き換えてください**

## GET, POST

### Input
- user_id: ツイッターのユーザー id

### Return
- 現在から一週間分の日ごとに集計したレポート

```json
"reports": [
  {
    "date": "YYYY/MM/DD" 日にち,
    "positives": 0 ポジティブの数,
    "negatives": 0 ネガティブの数,
    "tweets": [
      {
        "text": "String" ツイート内容,
        "created_at": "YYYY/MM/DD HH:mm:ss" ツイートされた日時,
        "p_or_n": "negative" もしくは "positive"
      }, 
      ...
    ]
  },
  ...
]
```

# RecentlyReports
最新のレポートを取得する API

https://jphacks-e2007.azurewebsites.net/api/tweets-analysis/{user_id}/recently-reports?num=20

**{user_id} をツイッターのユーザー id に置き換えてください**

## GET, POST

### Input
- user_id: ツイッターのユーザー id
- num: ツイート取得件数(デフォルトは 20)

### Return
- 現在から指定した回数文集計したレポート

```json
"reports": {
  "positives": 0 ポジティブの数,
  "negatives": 0 ネガティブの数,
  "tweets": [
    {
      "text": "String" ツイート内容,
      "created_at": "YYYY/MM/DD HH:mm:ss" ツイートされた日時,
      "p_or_n": "negative" もしくは "positive"
    }, 
    ...
  ]
}
```