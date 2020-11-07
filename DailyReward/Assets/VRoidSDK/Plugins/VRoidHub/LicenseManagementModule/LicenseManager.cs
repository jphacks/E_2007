
namespace VRoidSDK
{
    /// <summary>
    /// CachedLicenseに関する機能をまとめたマネージャクラス
    /// </summary>
    public class LicenseManager
    {
        /// <summary>
        /// Downloadしたライセンス情報をもとにLocalStorageに保存するキャッシュライセンスを作成する
        /// </summary>
        /// <param name="license">ダウンロードライセンス</param>
        /// <returns></returns>
        public static CachedLicense LicenseCache(DownloadLicense license)
        {
            return new CachedLicense(license);
        }

        /// <summary>
        /// LocalStorageからキャラクタモデルIDをもとにダウンロードライセンスを取得する
        /// </summary>
        /// <param name="characterModelId">キャラクタモデルID</param>
        /// <returns>キャッシュライセンス</returns>
        public static CachedLicense? LoadExistLicense(string characterModelId)
        {
            if (!LocalStorage.HasKey(characterModelId))
            {
                return null;
            }

            var cachedLicense = LocalStorage.GetGenericObject<CachedLicense>(characterModelId);
            if (!EncryptionModelFile.ExistsFile(cachedLicense.filePath))
            {
                return null;
            }

            return cachedLicense;
        }

        /// <summary>
        /// 保存しているキャッシュ情報をmaxCacheCount件に減らし、モデルファイルも削除する
        /// </summary>
        /// <param name="maxCacheCount">最大件数</param>
        public static void CleanCache(uint maxCacheCount)
        {
            var deletedLicenses = CachedLicense.CleanCache(maxCacheCount);
            foreach (var lic in deletedLicenses)
            {
                EncryptionModelFile.DeleteFile(lic.filePath);
            }
        }
    }
}
