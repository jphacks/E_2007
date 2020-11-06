import json
import logging

import azure.functions as func

from .src.counter import create_counter


def main(req: func.HttpRequest, db: func.Out[func.Document], reports: func.DocumentList) -> func.HttpResponse:
    # ==========
    # define vars
    user_id = req.route_params.get('userId')
    num = req.params.get('num')
    num = int(num) if isinstance(num, str) and num.isdigit() else 1
    report = len(reports) and reports[0]
    logging.info(f'Python HTTP trigger function processed a request. user_id = {user_id}')

    # ==========
    # increment counter
    counter = create_counter(num)
    if not report:
        new_report = {
            "user_id": user_id,
            "counter": [counter] 
        }
    else:
        new_report = {
            **report,
            "counter": [counter, *report["counter"]] if "counter" in report else [counter] 
        }
    db.set(func.Document.from_dict(new_report))

    # ==========
    # response
    resp_data = new_report["counter"][:5]
    
    return func.HttpResponse(json.dumps({'reports': resp_data}, ensure_ascii=False), headers={'Content-Type': 'application/json'})
