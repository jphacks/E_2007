import datetime
import logging
import json
import os

import azure.functions as func
import tweepy


consumer_key = os.environ["CONSUMER_API_KEY"]
consumer_secret =  os.environ["CONSUMER_SECRET_KEY"]
access_token=  os.environ["ACCESS_TOKEN_KEY"]
access_token_secret =  os.environ["ACCESS_TOKEN_SECRET"]


def main(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')

    user_id = req.params.get('user_id')
    if not user_id:
        try:
            req_body = req.get_json()
        except ValueError:
            pass
        else:
            user_id = req_body.get('user_id')
    if not user_id:
        return func.HttpResponse(
             "This HTTP triggered function executed successfully. Pass a user_id in the query string or in the request body for a personalized response.",
             status_code=200
        )
    
    auth = tweepy.OAuthHandler(consumer_key, consumer_secret)
    auth.set_access_token(access_token, access_token_secret)
    api = tweepy.API(auth)

    result = []
    for tweet in tweepy.Cursor(api.user_timeline, id=user_id).items(10):
        print("="*8)
        print(tweet.user.profile_image_url)
        print(tweet.user.name)
        print(tweet.user.screen_name)
        print(tweet.text)
        print(tweet.created_at)
        tweet_info = {
            "user_id": tweet.user.screen_name,
            "text": tweet.text,
            "created_at": tweet.created_at.strftime("%Y/%m/%d %H:%M:%S")
        }
        result.append(tweet_info)

    return func.HttpResponse(json.dumps({"summary": result}), headers={"Content-Type": "application/json"})
