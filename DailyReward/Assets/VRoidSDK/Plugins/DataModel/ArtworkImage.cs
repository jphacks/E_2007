
namespace VRoidSDK
{
    /// <summary>
    /// アートワークの画像
    /// </summary>
    public class ArtworkImage
    {
        /// <summary>
        /// オリジナルの画像
        /// </summary>
        public WebImage original;

        /// <summary>
        /// 正方形の一辺が600の画像
        /// </summary>
        public WebImage sq600;

        /// <summary>
        /// 正方形の一辺が300の画像
        /// </summary>
        public WebImage sq300;

        /// <summary>
        /// 1200x1200に収まるように縮小された画像
        /// </summary>
        public WebImage shrinked1200x1200;

        /// <summary>
        /// 600x1200に収まるように縮小された画像
        /// </summary>
        public WebImage shrinked600x1200;
    }
}
