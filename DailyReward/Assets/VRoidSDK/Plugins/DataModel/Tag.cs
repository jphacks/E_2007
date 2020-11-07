
namespace VRoidSDK
{
    /// <summary>
    /// タグの情報
    /// </summary>
    public struct Tag
    {
        /// <summary>
        /// タグ名
        /// </summary>
        public string name;

        /// <summary>
        /// タグのロケール
        /// </summary>
        /// <remarks>
        /// ロケール設定していない場合はnullになる
        /// </remarks>
        public string locale;

        /// <summary>
        /// タグの英語表記
        /// </summary>
        /// <remarks>
        /// 英語表記がない場合はnullになる
        /// </remarks>
        public string en_name;

        /// <summary>
        /// タグの日本語表記
        /// </summary>
        /// <remarks>
        /// 日本語表記がない場合はnullになる
        /// </remarks>
        public string ja_name;
    }
}
