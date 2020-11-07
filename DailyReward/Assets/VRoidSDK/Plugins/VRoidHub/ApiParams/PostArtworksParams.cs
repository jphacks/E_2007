using System;
using System.Collections.Generic;
using UnityEngine;
using VRoidSDK;
using VRoidSDK.Networking;

namespace VRoidSDK
{
    /// <summary>
    /// アートワークに付随するの情報作成に必要なパラメータ
    /// </summary>
    public class PostArtworksParams : IHttpParam
    {
        /// <summary>
        /// アートワークのキャプション
        /// </summary>
        public string caption;

        /// <summary>
        /// 撮影に使用したアプリのID
        /// </summary>
        public string capture_application_id;

        /// <summary>
        /// コンテスト
        /// </summary>
        public string contest_slug;

        /// <summary>
        /// 年齢制限
        /// </summary>
        public EnumAgeLimit? age_limit;

        /// <summary>
        /// 添付するメディアのID一覧
        /// </summary>
        public List<string> medium_ids;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="caption">アートワークの説明文</param>
        /// <param name="age_limit">年齢制限</param>
        /// <param name="medium_ids">メディアのID一覧</param>
        public PostArtworksParams(string caption, EnumAgeLimit age_limit, List<string> medium_ids)
        {
            this.caption = caption;
            this.age_limit = age_limit;
            this.medium_ids = medium_ids;
        }

        public WWWForm GetParam()
        {
            WWWForm requestParams = new WWWForm();

            if (caption != null)
            {
                requestParams.AddField("caption", caption);
            }
            if (capture_application_id != null)
            {
                requestParams.AddField("capture_application_id", capture_application_id);
            }

            if (contest_slug != null)
            {
                requestParams.AddField("contest_slug", contest_slug);
            }

            if (age_limit != null)
            {
                requestParams.AddField("age_limit", age_limit.Value.ToString());
            }

            if (medium_ids != null)
            {
                foreach (var medium_id in medium_ids)
                {
                    requestParams.AddField("medium_ids[]", medium_id);
                }
            }

            return requestParams;
        }
    }
}
