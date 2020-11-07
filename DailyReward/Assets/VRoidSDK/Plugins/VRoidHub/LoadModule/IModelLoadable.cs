using UnityEngine.Networking;

namespace VRoidSDK
{
    /// <summary>
    /// ダウンロードライセンスをもとにモデルバージョンファイルをロードる手法を提供するインターフェース
    /// </summary>
    public interface IModelLoadable
    {
        /// <summary>
        /// モデルデータをロードする
        /// </summary>
        /// <param name="license">ロードに使用するダウンロードライセンス</param>
        /// <returns>ロードしたバイナリデータ</returns>
        byte[] Load(DownloadLicense license);
    }
}
