
namespace VRoidSDK
{
    /// <summary>
    /// ユーザ設定情報
    /// </summary>
    public struct Account
    {
        /// <summary>
        /// 言語設定
        /// </summary>
        public string locale;

        /// <summary>
        /// プロフィール
        /// </summary>
        public UserDetail user_detail;

        /// <summary>
        /// 年齢制限
        /// </summary>
        public AgeLimit age_limit;
    }
}
