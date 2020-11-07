using System;
using System.Collections.Generic;

namespace VRoidSDK
{
    /// <summary>
    /// OAuth連携アプリケーション
    /// </summary>
    public class OauthApplication
    {
        /// <summary>
        /// アプリケーションのID
        /// </summary>
        public string id;

        /// <summary>
        /// アプリケーションの名前
        /// </summary>
        public string name;

        /// <summary>
        /// アプリケーションのweb site
        /// </summary>
        public string web_site;

        /// <summary>
        /// アプリケーションの説明
        /// </summary>
        public string description;

        /// <summary>
        /// アプリケーションの説明を分割した情報
        /// </summary>
        public List<DescriptionFragment> description_fragments;

        /// <summary>
        /// アプリケーションのアイコン
        /// </summary>
        public ApplicationIcon icon;

        /// <summary>
        /// 年齢制限
        /// </summary>
        public AgeLimit age_limit;

        /// <summary>
        /// アイキャッチ画像
        /// </summary>
        public EyecatchImage primary_eyecatch_image;
    }
}
