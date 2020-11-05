import datetime

import tweepy
from .config import CONSUMER_API_KEY, CONSUMER_SECRET_KEY, ACCESS_TOKEN_KEY, ACCESS_TOKEN_SECRET, DATE_FORMAT


def get_all_tweets(user_id: str, from_dt: datetime or None = None) -> list:
    """あるユーザーの、指定した日以降のツイート情報を取得する

    Args:
        user_id (str): ツイッターid
        from_dt (datetimeorNone, optional): 指定日. Defaults to None.

    Returns:
        list: ツイートのリスト
    """
    auth = tweepy.OAuthHandler(CONSUMER_API_KEY, CONSUMER_SECRET_KEY)
    auth.set_access_token(ACCESS_TOKEN_KEY, ACCESS_TOKEN_SECRET)
    api = tweepy.API(auth)

    result = []
    # 大きすぎると大変なので、最大で100ツイートにする。
    for tweet in tweepy.Cursor(api.user_timeline, id=user_id).items(50):
        tweeted_at = tweet.created_at + datetime.timedelta(hours=9)
        # 更新日より前のツイートを持ってきた段階で切る。
        if from_dt is not None and tweeted_at <= from_dt:
            break

        tweet_info = {
            "text": tweet.text,
            "created_at": tweet.created_at.strftime(DATE_FORMAT)
        }
        result.append(tweet_info)

    return result


def filter_tweets(tweets: list) -> list:
    return tweets
