using System;
using System.IO;
using System.Security.Cryptography;

namespace VRoidSDK
{
    /// <summary>
    /// ダウンロードライセンスをもとにモデルバージョンファイルをロードする
    /// </summary>
    public class EncryptModelLoad : IModelLoadable
    {
        private Func<string, byte[]> _decryptFunc;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="decryptFunc">モデルファイルの読み込みを行う関数
        /// </param>
        public EncryptModelLoad(Func<string, byte[]> decryptFunc)
        {
            _decryptFunc = decryptFunc;
        }

        /// <summary>
        /// モデルデータをロードする
        /// </summary>
        /// <param name="license">ロードに使用するダウンロードライセンス</param>
        /// <returns>ロードしたバイナリデータ</returns>
        /// <exception cref="FileNotFoundException">ファイルが存在しない</exception>
        /// <exception cref="CryptographicException">ファイルの復号に失敗</exception>
        public byte[] Load(DownloadLicense license)
        {
            if (!LocalStorage.HasKey(license.character_model_id))
            {
                throw new FileNotFoundException(string.Format("CharacterModel {0} is not found", license.character_model_id));
            }

            CachedLicense cachedLicense = LocalStorage.GetGenericObject<CachedLicense>(license.character_model_id);
            byte[] binary = _decryptFunc(cachedLicense.filePath);
            cachedLicense.UpdateLastAccessTime();
            cachedLicense.Save();
            return binary;
        }
    }
}
