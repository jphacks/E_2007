using System.Linq;
using System.Collections.Generic;
using System;

namespace VRoidSDK
{
    /// <summary>
    /// キャッシュしたダウンロードライセンス
    /// </summary>
    public struct CachedLicense
    {
        /// <summary>
        /// キャッシュしたダウンロードライセンス
        /// </summary>
        public DownloadLicense downloadLicense;

        /// <summary>
        /// ファイルの保存先
        /// </summary>
        public string filePath;

        /// <summary>
        /// 最後に利用した時刻
        /// </summary>
        public DateTime lastAccessTime;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="license">キャッシュするダウンロードライセンス</param>
        public CachedLicense(DownloadLicense license)
        {
            downloadLicense = license;
            filePath = license.FileName;
            lastAccessTime = DateTime.Now.ToLocalTime();
        }

        /// <summary>
        /// キャッシュしているダウンロードライセンスと、他のダウンロードライセンスで同じモデルデータを使用しているか判定する
        /// </summary>
        /// <remarks>
        /// character_model_idとcharacter_model_versionがそれぞれ一致するか判定している
        /// </remarks>
        /// <param name="otherLicense">他のダウンロードライセンス</param>
        /// <returns>同一のモデルを使用しているか</returns>
        public bool IsSameModel(DownloadLicense otherLicense)
        {
            return (
                downloadLicense.character_model_id == otherLicense.character_model_id &&
                downloadLicense.character_model_version_id == otherLicense.character_model_version_id
            );
        }

        /// <summary>
        /// キャッシュしているダウンロードライセンスと、キャラクターモデルで同じモデルデータを使用しているか判定する
        /// </summary>
        /// <remarks>
        /// character_model_idとcharacter_model_versionがそれぞれ一致するか判定している
        /// </remarks>
        /// <param name="characterModel">キャラクターモデル</param>
        /// <returns>同一のモデルを使用しているか</returns>
        public bool IsSameModel(CharacterModel characterModel)
        {
            return (
                downloadLicense.character_model_id == characterModel.id &&
                downloadLicense.character_model_version_id == characterModel.latest_character_model_version.id
            );
        }

        /// <summary>
        /// ダウンロードライセンスがすでに失効しているかを判定する
        /// </summary>
        /// <returns>ダウンロードライセンスが失効しているか</returns>
        public bool IsExpired()
        {
            return downloadLicense.IsExpired();
        }

        /// <summary>
        /// モデルに対してこのダウンロードライセンスが利用可能か判定する
        /// </summary>
        /// <returns>ダウンロードライセンスが利用可能か</returns>
        public bool IsAvailable(CharacterModel characterModel)
        {
            return !IsExpired() && IsSameModel(characterModel);
        }

        /// <summary>
        /// ローカルストレージ中にキャッシュ情報を保存する
        /// </summary>
        public void Save()
        {
            LocalStorage.SetValue(downloadLicense.character_model_id, this);
            LocalStorage.Save();
        }

        /// <summary>
        /// ローカルストレージ中にキャッシュ情報を保存する
        /// </summary>
        public void UpdateDownloadLicense(DownloadLicense newDownloadLicense)
        {
            downloadLicense = newDownloadLicense;
            filePath = newDownloadLicense.FileName;
            UpdateLastAccessTime();
        }

        public void UpdateLastAccessTime()
        {
            lastAccessTime = DateTime.Now.ToLocalTime();
        }

        /// <summary>
        /// キャッシュ情報をクリアする
        /// </summary>
        public void Clean()
        {
            LocalStorage.DeleteKey(this.downloadLicense.character_model_id);
        }

        /// <summary>
        /// 保存しているキャッシュ情報をmaxCacheCount件に減らす
        /// </summary>
        /// <param name="maxCacheCount">最大件数</param>
        /// <remarks>モデルファイルのキャッシュ情報は削除しないので、戻り値を元に個別に削除する必要があります。</remarks>
        /// <returns>削除されたライセンス情報の一覧</returns>
        public static CachedLicense[] CleanCache(uint maxCacheCount)
        {
            var licenses = LocalStorage.GetGenericObjectArray<CachedLicense>();

            licenses = licenses
                            .OrderBy((x) => x.lastAccessTime)
                            .Take((int)(licenses.Length - maxCacheCount))
                            .ToArray();

            foreach (var lic in licenses)
            {
                lic.Clean();
            }

            return licenses;
        }
    }
}
