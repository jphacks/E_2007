
namespace VRoidSDK
{
    /// <summary>
    /// アカウントに設定可能なロケール
    /// </summary>
    public struct Locale
    {
        /// <summary>
        /// ロケール表記
        /// </summary>
        /// <remarks>
        /// <para>ja: 日本語</para>
        /// <para>en: 英語</para>
        /// <para>zh-CN: 簡体字</para>
        /// <para>zh-TW: 簡体字</para>
        /// </remarks>
        public string value;

        /// <summary>
        /// 言語設定のラベル
        /// </summary>
        public string label;

        /// <summary>
        /// 言語設定のラベル (英語表記)
        /// </summary>
        /// <example>
        /// 日本語　-> Japanese
        /// </example>
        public string label_en;
    }
}
