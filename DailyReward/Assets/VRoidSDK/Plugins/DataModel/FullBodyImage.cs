
namespace VRoidSDK
{
    /// <summary>
    /// 全身画像
    /// </summary>
    public struct FullBodyImage
    {
        /// <summary>
        /// オリジナル画像
        /// </summary>
        public WebImage original;

        /// <summary>
        /// 幅600に変換された画像
        /// </summary>
        public WebImage w600;

        /// <summary>
        /// 幅300に変換された画像
        /// </summary>
        public WebImage w300;
    }
}
