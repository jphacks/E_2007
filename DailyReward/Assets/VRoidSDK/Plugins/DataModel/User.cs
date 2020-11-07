
namespace VRoidSDK
{
    /// <summary>
    /// ユーザの情報
    /// </summary>
    public struct User
    {
        /// <summary>
        /// ユーザID
        /// </summary>
        public string id;

        /// <summary>
        /// ピクシブアカウントのユーザID
        /// </summary>
        public string pixiv_user_id;

        /// <summary>
        /// ユーザ名
        /// </summary>
        public string name;

        /// <summary>
        /// ユーザのアイコン
        /// </summary>
        public UserIcon icon;
    }
}
