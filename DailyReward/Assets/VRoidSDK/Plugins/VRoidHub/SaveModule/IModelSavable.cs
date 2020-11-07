using UnityEngine.Networking;

namespace VRoidSDK
{
    /// <summary>
    /// モデルバージョンファイルを保存する手法を提供するインターフェース
    /// </summary>
    public interface IModelSavable
    {
        /// <summary>
        /// モデルデータを保存する
        /// </summary>
        /// <param name="license">保存するダウンロードライセンス</param>
        /// <param name="downloadedData">保存するバイナリデータ</param>
        void Save(DownloadLicense license, byte[] downloadedData);
    }
}
