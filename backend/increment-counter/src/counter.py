import datetime

from .config import DATE_FORMAT, ENV

def get_now():
    if ENV == "local":
        return datetime.datetime.now()
    else:
        return datetime.datetime.now() + datetime.timedelta(hours=9)


def create_counter(num: int) -> dict:
    return {
        "created_at": get_now().strftime(DATE_FORMAT),
        "num": num
    }