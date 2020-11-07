using System;
using UnityEngine;

namespace VRoidSDK
{
    /// <summary>
    /// キャッシュファイルの情報
    /// </summary>
    [Serializable]
    public class CacheFileInfo : ISerializationCallbackReceiver
    {
        [SerializeField]
        private string _filePath;

        [SerializeField]
        private string _lastAccessTime;
        [SerializeField]
        private string _expiresAt;

        /// <summary>
        /// ファイルの保存先
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 最後に利用した時刻
        /// </summary>
        public DateTime LastAccessTime { get; set; }

        /// <summary>
        /// キャッシュの期限
        /// </summary>
        /// <remarks>
        /// nullの場合は無期限
        /// </remarks>
        public DateTime? ExpiresAt { get; set; }

        public void OnBeforeSerialize()
        {
            _filePath = FilePath;
            _lastAccessTime = LastAccessTime.ToString("O");
            _expiresAt = ExpiresAt != null ? ExpiresAt.Value.ToString("O") : null;
        }

        public void OnAfterDeserialize()
        {
            FilePath = _filePath;
            LastAccessTime = ParseDateTime(_lastAccessTime) ?? new DateTime(0);
            ExpiresAt = ParseDateTime(_expiresAt);
        }

        /// <summary>
        /// 最後に利用した時刻を更新
        /// </summary>
        public void UpdateLastAccessTime()
        {
            LastAccessTime = DateTime.Now;
        }

        /// <summary>
        /// キャッシュの期限を延長
        /// 設定済みの期限の方が長かったり無期限の場合は変更されない
        /// </summary>
        public void UpdateToLongestExpirationTime(DateTime newExpiresAt)
        {
            if (ExpiresAt != null && newExpiresAt > ExpiresAt.Value)
            {
                ExpiresAt = newExpiresAt;
            }
        }

        /// <summary>
        /// キャッシュの期限を無期限に設定
        /// </summary>
        public void DisableExpiration()
        {
            ExpiresAt = null;
        }

        /// <summary>
        /// 保存期限を過ぎているか
        /// </summary>
        /// <returns>失効時間超過: true, それ以外: false</returns>
        public bool IsExpired()
        {
            return ExpiresAt != null && ExpiresAt.Value < DateTime.Now;
        }

        private DateTime? ParseDateTime(string dateTimeText)
        {
            if (string.IsNullOrEmpty(dateTimeText))
            {
                return null;
            }

            try
            {
                return DateTime.Parse(dateTimeText);
            }
            catch (FormatException)
            {
                return null;
            }
        }
    }
}
