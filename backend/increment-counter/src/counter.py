import datetime

from .config import DATE_FORMAT


def create_counter(num: int) -> dict:
    return {
        "created_at": datetime.datetime.now().strftime(DATE_FORMAT),
        "num": num
    }