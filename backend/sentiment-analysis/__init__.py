import logging
import json

import azure.functions as func

from . import analysis


def main(req: func.HttpRequest) -> func.HttpResponse:
    logging.info('Python HTTP trigger function processed a request.')

    txt = req.params.get('txt')
    if not txt:
        try:
            req_body = req.get_json()
        except ValueError:
            pass
        else:
            txt = req_body.get('txt')

    analyzer = analysis.get_analyzer()
    if txt:
        pos_or_neg = analyzer(txt)
        return func.HttpResponse(json.dumps({'pos_or_neg': pos_or_neg}))
    else:
        return func.HttpResponse(
             "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.",
             status_code=200
        )
