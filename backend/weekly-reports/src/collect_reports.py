from datetime import datetime, timedelta

from .config import DATE_FORMAT


DAY_FORMAT = "%Y/%m/%d"

def _is_equal_day(d1: datetime, d2: datetime):
    return d1.year == d2.year and d1.month == d2.month and d1.day == d2.day


def collect_reports_weekly(tweets: list) -> list:
    str2date = lambda s: datetime.strptime(s, DATE_FORMAT)
    delta_day = timedelta(days=1)
    curr_date = datetime.now()
    twt_idx = 0

    result = []
    # 一週間
    for _ in range(7):
        neg_cnt = pos_cnt = 0
        daily_twts = []

        while twt_idx < len(tweets):
            twt_dt = str2date(tweets[twt_idx]["created_at"])
            if not _is_equal_day(twt_dt, curr_date):
                break

            if tweets[twt_idx]["p_or_n"] == "positive":
                pos_cnt += 1
            else:
                neg_cnt += 1

            daily_twts.append(tweets[twt_idx])
            twt_idx += 1

        result.append({
            "date": curr_date.strftime(DAY_FORMAT),
            "positives": pos_cnt,
            "negatives": neg_cnt,
            "tweets": daily_twts
        })
        curr_date -= delta_day
    
    return result

