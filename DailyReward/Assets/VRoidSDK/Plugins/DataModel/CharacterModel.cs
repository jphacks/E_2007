using System;
using System.Collections.Generic;

namespace VRoidSDK
{
    /// <summary>
    /// キャラクターモデルデータ
    /// </summary>
    public struct CharacterModel
    {
        /// <summary>
        /// キャラクターモデルID
        /// </summary>
        public string id;

        /// <summary>
        /// モデルの名前
        /// </summary>
        /// <remarks>
        /// 設定をしていない場合はnullになる
        /// </remarks>
        public string name;

        /// <summary>
        /// 非公開かどうか
        /// </summary>
        public bool is_private;

        /// <summary>
        /// VRMをWebページ上からのダウンロードが可能かどうか
        /// </summary>
        public bool is_downloadable;

        /// <summary>
        /// VRMをSDKで利用可能かどうか
        /// </summary>
        public bool is_other_users_available;

        /// <summary>
        /// 自分がこのモデルに対しハートしたか
        /// </summary>
        public bool is_hearted;

        /// <summary>
        /// バストアップ画像
        /// </summary>
        public PortraitImage portrait_image;

        /// <summary>
        /// 全身画像
        /// </summary>
        public FullBodyImage full_body_image;

        /// <summary>
        /// モデルの作成日時
        /// </summary>
        public string created_at;

        /// <summary>
        /// ハートされている数
        /// </summary>
        public long heart_count;

        /// <summary>
        /// ダウンロードされた数
        /// </summary>
        public long download_count;

        /// <summary>
        /// モデル利用のためにダウンロードライセンスを発行した数
        /// </summary>
        public long usage_count;

        /// <summary>
        /// 閲覧数
        /// </summary>
        public long view_count;

        /// <summary>
        /// 公開日時
        /// </summary>
        /// <remarks>
        /// 公開したことがない場合はnullになる
        /// </remarks>
        public string published_at;

        /// <summary>
        /// 利用条件
        /// </summary>
        public CharacterLicense license;

        /// <summary>
        /// 設定されているタグ
        /// </summary>
        public List<Tag> tags;

        /// <summary>
        /// 年齢制限
        /// </summary>
        public AgeLimit age_limit;

        /// <summary>
        /// 紐づいているキャラクター
        /// </summary>
        public Character character;

        /// <summary>
        /// モデルのバージョン
        /// </summary>
        public CharacterModelVersion latest_character_model_version;

        /// <summary>
        /// モデルを作成した日時を取得する
        /// </summary>
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
        /// モデルを公開した日時を取得する
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
