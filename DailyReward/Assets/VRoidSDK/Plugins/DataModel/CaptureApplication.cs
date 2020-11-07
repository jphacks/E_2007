
namespace VRoidSDK
{
    /// <summary>
    /// 撮影に利用したアプリケーション
    /// </summary>
    public class CaptureApplication
    {
        /// <summary>
        /// アプリケーションのID
        /// </summary>
        public string id;

        /// <summary>
        /// アプリケーションの名前
        /// </summary>
        public string name;

        /// <summary>
        /// アプリケーションのweb site
        /// </summary>
        public string web_site;

        /// <summary>
        /// OAuth連携アプリケーション
        /// </summary>
        /// <remarks>
        /// VRoidSDKと連携したアプリケーションの開発者が設定した情報を取得する
        /// SDK連携をしていないアプリケーションの場合はnullになる
        /// </remarks>
        public OauthApplication application;
    }
}
