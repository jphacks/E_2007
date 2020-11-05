import datetime
import logging

import azure.functions as func

from .src.config import DATE_FORMAT
from .src import analyze_tweets, collect_tweets


def main(req: func.HttpRequest, db: func.Out[func.Document], reports: func.DocumentList) -> func.HttpResponse:
    # ==========
    # define vars
    user_id = req.route_params.get('userId')
    report = len(reports) and reports[0]
    now_dt = datetime.datetime.now()
    logging.info(f'Python HTTP trigger function processed a request. user_id = {user_id}')

    # ==========
    # collect tweets
    logging.info(f'Get tweets and filter them.')
    logging.info(f'report = {report}')
    if report:
        updated_at = datetime.datetime.strptime(report["updated_at"], DATE_FORMAT)
        tweets = collect_tweets.get_all_tweets(user_id, updated_at)
    else:
        tweets = collect_tweets.get_all_tweets(user_id)
    filtered_tweets = collect_tweets.filter_tweets(tweets)

    # ==========
    # analyze tweets
    logging.info("Analyze tweets.")
    analyzed_tweets = analyze_tweets.analyze_tweets(filtered_tweets)

    # ==========
    # Add or Update DB
    if report:
        new_report = {
            **report,
            "updated_at": now_dt.strftime(DATE_FORMAT),
            "tweets": [*analyzed_tweets, *report['tweets']]
        }
    else: 
        new_report = {
            "user_id": user_id,
            "updated_at": now_dt.strftime(DATE_FORMAT),
            "tweets": analyzed_tweets
        }
    db.set(func.Document.from_dict(new_report))

    return func.HttpResponse(f"SUCCESS")