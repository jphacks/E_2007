using System;
using System.Collections.Generic;

namespace VRoidSDK
{
    /// <summary>
    /// アートワークのコンテストデータ
    /// </summary>
    public class Contest
    {
        /// <summary>
        /// コンテストのSlug
        /// </summary>
        public string slug;

        /// <summary>
        /// コンテストの名前
        /// </summary>
        public string name;

        /// <summary>
        /// コンテストの開始時期
        /// </summary>
        public string start_at;

        /// <summary>
        /// コンテストの終了時期
        /// </summary>
        public string end_at;

        /// <summary>
        /// コンテストの状態
        /// </summary>
        public EnumContestStatusType status;

        /// <summary>
        /// アイキャッチ画像
        /// </summary>
        public ContestOgpImage ogp_image;
    }
}
