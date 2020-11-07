using System;

namespace VRoidSDK
{
    /// <summary>
    /// VRoidHubからモデルをダウンロードするためのライセンス情報
    /// </summary>
    public struct DownloadLicense
    {
        /// <summary>
        /// ダウンロードライセンスID
        /// </summary>
        public string id;

        /// <summary>
        /// キャラクターモデルのID
        /// </summary>
        public string character_model_id;

        /// <summary>
        /// キャラクターモデルのバージョンID
        /// </summary>
        public string character_model_version_id;

        /// <summary>
        /// ダウンロードライセンスの失効時間
        /// </summary>
        public string expires_at;

        /// <summary>
        /// ライセンスファイルのファイル名を取得する
        /// </summary>
        /// <returns>保存されるファイル名</returns>
        public string FileName
        {
            get
            {
                return string.Format("{0}_{1}", character_model_id, character_model_version_id);
            }
        }

        /// <summary>
        /// ダウンロードライセンスの失効時間を取得する
        /// </summary>
        /// <returns>失効時間</returns>
        public DateTime ExpiresAtDateTime()
        {
            return DateTime.Parse(expires_at);
        }

        /// <summary>
        /// ダウンロードライセンスがすでに失効しているかを判定する
        /// </summary>
        /// <returns>ダウンロードライセンスが失効しているか</returns>
        public bool IsExpired()
        {
            return DateTime.Now > ExpiresAtDateTime();
        }
    }
}
