import json
import logging

import azure.functions as func
from .src.collect_reports import collect_recently_reports


def main(req: func.HttpRequest, reports: func.DocumentList) -> func.HttpResponse:
    # ==========
    # define vars
    user_id = req.route_params.get('userId')
    num = req.params.get('num')
    num = int(num) if isinstance(num, str) and num.isdigit() else 20
    report = len(reports) and reports[0]
    if not report:
        return func.HttpResponse(f"report not found. user_id = {user_id}", status_code=404)

    logging.info(f'Python HTTP trigger function processed a request. user_id = {user_id}, num = {num}')

    # ==========
    # collect reports
    logging.info(f'Collect recently reports.')
    resp_data = collect_recently_reports(report["tweets"], num)

    return func.HttpResponse(json.dumps({'reports': resp_data}, ensure_ascii=False), headers={'Content-Type': 'application/json'})
