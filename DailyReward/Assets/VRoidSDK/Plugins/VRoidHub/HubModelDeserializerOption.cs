
namespace VRoidSDK
{
    /// <summary>
    /// HubModelDeserializerのオプション
    /// </summary>
    public class HubModelDeserializerOption
    {
        /// <summary>
        /// 最大で保持するキャッシュの数
        /// </summary>
        /// <remarks>
        /// デフォルト: 10
        /// </remarks>
        public uint MaxCacheCount = 10;

        /// <summary>
        /// ダウンロードのタイムアウト(秒)
        /// </summary>
        /// <remarks>
        /// デフォルト: 300
        /// </remarks>
        public int DownloadTimeout = 300;
    }
}
