using System;

namespace VRoidSDK
{
    /// <summary>
    /// リンク先情報
    /// </summary>
    public struct ApiLink
    {
        /// <summary>
        /// リンク先
        /// </summary>
        public string href;

        /// <summary>
        /// リンク先を取得する
        /// </summary>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <typeparam name="T">リクエスト結果の型</typeparam>
        public void RequestLink<T>(Action<T, ApiLinksFormat> onSuccess, Action<ApiErrorFormat> onError)
        {
            if (href == null)
            {
                onError(new ApiErrorFormat()
                {
                    code = "UNKNOWN_ERROR",
                    message = "href is null"
                });
                return;
            }

            var request = new GenericDataRequest<T>(href);
            request.SendRequest(onSuccess, onError);
        }
    }
}
