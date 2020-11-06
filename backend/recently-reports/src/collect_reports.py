def collect_recently_reports(tweets: list, num: int) -> list:
    neg_cnt = pos_cnt = 0
    loop_num = min(num, len(tweets))

    for i in range(loop_num):
        if tweets[i]["p_or_n"] == "positive":
            pos_cnt += 1
        else:
            neg_cnt += 1

    result = {
        "positives": pos_cnt,
        "negatives": neg_cnt,
        "tweets": tweets[:loop_num]
    }

    return result
