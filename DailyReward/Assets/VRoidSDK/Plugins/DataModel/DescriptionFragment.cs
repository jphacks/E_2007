
namespace VRoidSDK
{
    /// <summary>
    /// モデル説明文を分割した断片
    /// </summary>
    public struct DescriptionFragment
    {
        /// <summary>
        /// 型 (plain, url, tag)
        /// </summary>
        public EnumDescriptionFragmentType type;

        /// <summary>
        /// 内容
        /// </summary>
        public string body;

        /// <summary>
        /// bodyを整理した内容
        /// <para>url: URLからスキーム部分を取り除いたもの</para>
        /// <para>plain: bodyと同じ</para>
        /// <para>tag: タグから#を取り除いたもの</para>
        /// </summary>
        public string normalized_body;
    }
}
