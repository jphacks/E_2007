
namespace VRoidSDK
{
    /// <summary>
    /// 画像データの情報
    /// </summary>
    public struct WebImage
    {
        /// <summary>
        /// 画像データへのリンク
        /// </summary>
        public string url;

        /// <summary>
        /// 2倍サイズへの画像リンク
        /// </summary>
        /// <remarks>
        /// 2倍サイズがない場合はnullを返す
        /// </remarks>
        public string url2x;

        /// <summary>
        /// 画像の幅
        /// </summary>
        public int width;

        /// <summary>
        /// 画像の高さ
        /// </summary>
        public int height;
    }
}
