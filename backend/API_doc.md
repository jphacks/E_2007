# TweetsAnalysis
ツイッターのツイート内容を分析する API

https://jphacks-e2007.azurewebsites.net/api/tweets-analysis/{user_id}?code=IsgyAkdiqg6CXP3jd6wetsiBLhlslZN5Sd0k8xPdaECZlzDNGJxRBA==

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