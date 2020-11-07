using System;
using System.Collections.Generic;

namespace VRoidSDK
{
    /// <summary>
    /// キャラクター情報
    /// </summary>
    public struct Character
    {
        /// <summary>
        /// キャラクターのID
        /// </summary>
        public string id;

        /// <summary>
        /// キャラクター名
        /// </summary>
        public string name;

        /// <summary>
        /// 非公開かどうか
        /// </summary>
        public bool is_private;

        /// <summary>
        /// 作成日時
        /// </summary>
        public string created_at;

        /// <summary>
        /// 公開した日時
        /// </summary>
        /// <remarks>
        /// 公開したことがない場合はnullになる
        /// </remarks>
        public string published_at;

        /// <summary>
        /// 投稿したユーザ
        /// </summary>
        public User user;

        /// <summary>
        /// キャラクターを作成した日時を取得する
        /// </summary>
        /// <remarks>
        /// created_atがnullか空文字だった場合は、nullを返す
        /// </remarks>
        /// <returns>作成日時</returns>
        public DateTime? CreatedAt()
        {
            if (string.IsNullOrEmpty(created_at))
            {
                return null;
            }
            return DateTime.Parse(created_at);
        }

        /// <summary>
        /// キャラクターを公開した日時を取得する
        /// </summary>
        /// <remarks>
        /// published_atがnullか空文字だった場合は、nullを返す
        /// </remarks>
        /// <returns>公開日時</returns>
        public DateTime? PublishedAt()
        {
            if (string.IsNullOrEmpty(published_at))
            {
                return null;
            }
            return DateTime.Parse(published_at);
        }
    }
}
