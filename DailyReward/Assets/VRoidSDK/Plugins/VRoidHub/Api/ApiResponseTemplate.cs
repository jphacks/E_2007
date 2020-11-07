
namespace VRoidSDK
{
    /// <summary>
    /// VRoid HubApi のレスポンスをラッピングした構造体
    /// </summary>
    /// <typeparam name="T">レスポンスの型</typeparam>
    public struct ApiResponseTemplate<T>
    {
        /// <summary>
        /// レスポンスのデータ本体
        /// </summary>
        public T data;

        /// <summary>
        /// エラーが発生した時のエラー情報
        /// </summary>
        public ApiErrorFormat error;

        /// <summary>
        /// 次へのリンク
        /// </summary>
        public ApiLinksFormat _links;

        /// <summary>
        /// ランダムな文字列
        /// </summary>
        public string rand;
    }
}
