using System;
using UnityEngine.Networking;

namespace VRoidSDK
{
    /// <summary>
    /// モデルバージョンファイルを暗号化して保存する
    /// </summary>
    public class EncryptModelSave : IModelSavable
    {
        private Action<string, byte[]> _encryptFunc;
        private Action<string> _deleteFunc;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="encryptFunc">モデルファイルの暗号化を行う関数</param>
        /// <param name="deleteFunc">モデルファイルの削除を行う関数</param>
        public EncryptModelSave(Action<string, byte[]> encryptFunc, Action<string> deleteFunc)
        {
            _encryptFunc = encryptFunc;
            _deleteFunc = deleteFunc;
        }

        /// <summary>
        /// モデルデータを保存する
        /// </summary>
        /// <param name="license">保存するダウンロードライセンス</param>
        /// <param name="downloadedData">保存するバイナリデータ</param>
        public void Save(DownloadLicense license, byte[] downloadedData)
        {
            if (LocalStorage.HasKey(license.character_model_id))
            {
                CachedLicense before = LocalStorage.GetGenericObject<CachedLicense>(license.character_model_id);
                _deleteFunc(before.filePath);
            }
            var newCachedLicense = new CachedLicense(license);
            _encryptFunc(newCachedLicense.filePath, downloadedData);
            newCachedLicense.Save();
        }
    }
}
