import logging
import json

import azure.functions as func

from . import analysis


def main(req: func.HttpRequest) -> func.HttpResponse:
    # ======
    # get txt
    txt = req.params.get('txt')
    if not txt:
        try:
            req_body = req.get_json()
        except ValueError:
            pass
        else:
            txt = req_body.get('txt')
    logging.info(f'sentiment-analysis called: {txt}')
    if not txt:
        return func.HttpResponse(
             "This HTTP triggered function executed successfully. Pass a txt in the query string or in the request body for a personalized response.",
             status_code=200
        )

    # ======
    # analyze
    analyzer = analysis.get_analyzer()
    pos_or_neg = analyzer(txt)
    logging.info({'txt': txt, 'pos_or_neg': pos_or_neg})

    headers = {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
    }
    body_dict = {
        'pos_or_neg': pos_or_neg
    }
    
    return func.HttpResponse(json.dumps(body_dict), status_code=200, headers=headers)
