using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using VRoidSDK.Networking;
using VRoidSDK.OAuth;

namespace VRoidSDK
{
    /// <summary>
    /// 認証なしでVRoid HubのAPIをリクエストするためのクラス
    /// </summary>
    /// <typeparam name="T">リクエスト結果の型</typeparam>
    public class UnauthorizedApiRequestBase<T>
    {
        /// <summary>
        /// APIのリクエストパス
        /// </summary>
        /// <returns>`/api`から始まるリクエストパス</returns>
        public readonly string RequestPath;

        /// <summary>
        /// リクエストに使うメソッド
        /// </summary>
        /// <returns>リクエストメソッド (デフォルト: HTTPMethods.Get)</returns>
        public HTTPMethods Methods = HTTPMethods.Get;

        /// <summary>
        /// リクエストのヘッダ情報
        /// </summary>
        /// <returns>リクエストヘッダ (デフォルト: null)</returns>
        public Dictionary<string, string> Headers = null;

        /// <summary>
        /// リクエストのパラメータ
        /// </summary>
        /// <returns>リクエストパラメータ (デフォルト: null)</returns>
        public IHttpParam Params = null;

        /// <summary>
        /// リクエストのタイムアウト(秒)
        /// </summary>
        /// <returns>タイムアウト (デフォルト: 30)</returns>
        public int Timeout = 30;

        /// <summary>
        /// ダウンロードの進捗を取得するコールバック
        /// </summary>
        /// <returns>コールバック (デフォルト: null)</returns>
        public Action<float> OnDownloadProgress = null;

        /// <summary>
        /// アップロードの進捗を取得するコールバック
        /// </summary>
        /// <returns>コールバック (デフォルト: null)</returns>
        public Action<float> OnUploadProgress = null;

        /// <summary>
        /// WebResponseを加工するコンバーター
        /// </summary>
        /// <returns>コンバーター</returns>
        protected ResponseConverterBase<T> ResponseConverter;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="requestPath">リクエストするAPIのURL</param>
        public UnauthorizedApiRequestBase(string requestPath)
        {
            RequestPath = requestPath;
        }

        /// <summary>
        /// Apiへのリクエストを実行する
        /// </summary>
        /// <param name="onSuccess">APIへのリクエストに成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <typeparam name="T">成功した時の戻り値の型</typeparam>
        public void SendRequest(Action<T, ApiLinksFormat> onSuccess, Action<ApiErrorFormat> onError)
        {
            var url = new ApiUrl(EnvironmentConfig.HttpHostUrl, RequestPath);
            var requestHeader = new ApiHeader(Headers);
            var conn = ConnectionFactory.CreateHttpConnection(url, Methods, Params, requestHeader);
            if (onSuccess != null)
            {
                conn.OnSuccess = (response) => ResponseConverter.Convert(
                    response,
                    (responseTemplate) => onSuccess(responseTemplate.data, responseTemplate._links),
                    onError
                );
            }
            if (OnDownloadProgress != null)
            {
                conn.OnDownloadProgress = (value) => OnDownloadProgress.Invoke(value);
            }
            if (OnUploadProgress != null)
            {
                conn.OnUploadProgress = (value) => OnUploadProgress.Invoke(value);
            }
            if (onError != null)
            {
                conn.OnError = (error) => onError(ResponseConverter.ConvertError(error.Response));
            }
            conn.RequestAsync(Timeout);
        }

        /// <summary>
        /// Apiへのリクエストを実行する
        /// </summary>
        /// <param name="onSuccess">APIへのリクエストに成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <typeparam name="T">成功した時の戻り値の型</typeparam>
        public void SendRequest(Action<T> onSuccess, Action<ApiErrorFormat> onError)
        {
            SendRequest((data, links) => onSuccess(data), onError);
        }
    }
}
