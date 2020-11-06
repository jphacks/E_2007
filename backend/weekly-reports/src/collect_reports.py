from datetime import datetime, timedelta

from .config import DATE_FORMAT, ENV


DAY_FORMAT = "%Y/%m/%d"


def get_now():
    if ENV == "local":
        return datetime.now()
    else:
        return datetime.now() + timedelta(hours=9)


def _is_equal_day(d1: datetime, d2: datetime):
    return d1.year == d2.year and d1.month == d2.month and d1.day == d2.day


def collect_reports_weekly(tweets: list, counter: list) -> list:
    str2date = lambda s: datetime.strptime(s, DATE_FORMAT)
    delta_day = timedelta(days=1)
    curr_date = get_now()
    twt_idx = 0
    cnt_idx = 0

    result = []
    # 一週間
    for _ in range(7):
        neg_cnt = pos_cnt = cnt_cnt = 0
        daily_twts = []
        daily_cnts = []

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
        
        while cnt_idx < len(counter):
            cnt_dt = str2date(counter[cnt_idx]["created_at"])
            if not _is_equal_day(cnt_dt, curr_date):
                break
            
            cnt_cnt += counter[cnt_idx]["num"]
            daily_cnts.append(counter[cnt_idx])
            cnt_idx += 1

        result.append({
            "date": curr_date.strftime(DAY_FORMAT),
            "positives": pos_cnt,
            "negatives": neg_cnt,
            "counts": cnt_cnt,
            "tweets": daily_twts,
            "counter": daily_cnts
        })
        curr_date -= delta_day
    
    return result

