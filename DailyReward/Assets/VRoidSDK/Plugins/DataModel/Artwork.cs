using System;
using System.Collections.Generic;

namespace VRoidSDK
{
    /// <summary>
    /// アートワークの情報
    /// </summary>
    public class Artwork
    {
        /// <summary>
        /// アートワークのID
        /// </summary>
        public string id;

        /// <summary>
        /// メディアの数
        /// </summary>
        public int medium_count;

        /// <summary>
        /// アーカイブされているか
        /// </summary>
        public bool is_archived;

        /// <summary>
        /// 自分がこのアートワークに対しハートしたか
        /// </summary>
        public bool is_hearted;

        /// <summary>
        /// 作成日時
        /// </summary>
        public string created_at;

        /// <summary>
        /// アートワークのサムネイルメディア
        /// </summary>
        public ArtworkMediumSimple primary_medium;

        /// <summary>
        /// 投稿したユーザ
        /// </summary>
        public User user;

        /// <summary>
        /// 年齢制限
        /// </summary>
        public AgeLimit age_limit;
    }
}
