import json
import logging

import azure.functions as func

from .src.collect_reports import collect_reports_weekly


def main(req: func.HttpRequest, reports: func.DocumentList) -> func.HttpResponse:
    # ==========
    # define vars
    user_id = req.route_params.get('userId')
    report = len(reports) and reports[0]
    if not report:
        return func.HttpResponse(f"report not found. user_id = {user_id}", status_code=404)

    logging.info(f'Python HTTP trigger function processed a request. user_id = {user_id}')

    # ==========
    # collect reports
    logging.info(f'Collect weekly reports.')
    tweets = report["tweets"] if "tweets" in report else []
    counter = report["counter"] if "counter" in report else []
    weekly_reports = collect_reports_weekly(tweets, counter)

    return func.HttpResponse(json.dumps({'reports': weekly_reports}, ensure_ascii=False), headers={'Content-Type': 'application/json'})