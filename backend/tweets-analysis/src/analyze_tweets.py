from .sentiment_analysis.analyzer import SA


def analyze_tweets(tweets: list) -> list:
    """ツイートのポジティブ・ネガティブを判定する

    Args:
        tweets (list): ツイート一覧

    Returns:
        list: 判定結果が入ったリスト
    """
    sa = SA()

    result = []
    for tweet_info in tweets:
        p_or_n = sa.detect_p_or_n(tweet_info["text"])

        result.append({
            **tweet_info,
            "p_or_n": p_or_n
        })

    return result