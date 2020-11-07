
namespace VRoidSDK
{
    /// <summary>
    /// 関連のリンク情報
    /// </summary>
    /// <remarks>
    /// <see cref="HubApi.GetAccountCharacterModels"/>などでページャ実装(countを任意の数に指定)をした場合に、次のページ内容を取得するのに使う
    /// </remarks>
    /// <example>
    /// <code>
    ///  "_links": {
    ///      "next": {
    ///          "href": "/api/account/characters?count=3&amp;max_id=xxxxxxxxxxxxx"
    ///       }
    ///  }
    /// </code>
    /// </example>
    public struct ApiLinksFormat
    {
        /// <summary>
        /// 次のページを取得するためのリンク先情報
        /// </summary>
        public ApiLink? next;
    }
}
