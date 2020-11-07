using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using VRoidSDK.Networking;
using VRoidSDK.OAuth;

namespace VRoidSDK
{
    /// <summary>
    /// VRoid HubのAPIをリクエストするためのクラス
    /// </summary>
    /// <typeparam name="T">リクエスト結果の型</typeparam>
    public class ApiRequestBase<T>
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
        /// 認証機能を持ったモジュール
        /// </summary>
        /// <returns>認証機能を持ったモジュール</returns>
        protected IAuthentication Authenticate;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="requestPath">リクエストするAPIのURL</param>
        public ApiRequestBase(string requestPath)
        {
            RequestPath = requestPath;
            Authenticate = Authentication.Instance;
        }

        /// <summary>
        /// Apiへのリクエストを実行する
        /// </summary>
        /// <remarks>
        /// アクセストークンが切れていた場合は自動でリフレッシュして再度リクエストする
        /// </remarks>
        /// <param name="onSuccess">APIへのリクエストに成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <typeparam name="T">成功した時の戻り値の型</typeparam>
        public void SendRequest(Action<T, ApiLinksFormat> onSuccess, Action<ApiErrorFormat> onError)
        {
            SendRequest(onSuccess, null, onError);
        }

        /// <summary>
        /// Apiへのリクエストを実行する
        /// </summary>
        /// <remarks>
        /// アクセストークンが切れていた場合は自動でリフレッシュして再度リクエストする
        /// </remarks>
        /// <param name="onSuccess">APIへのリクエストに成功した時のコールバック</param>
        /// <param name="onProgress">APIリクエスト中のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <typeparam name="T">成功した時の戻り値の型</typeparam>
        public void SendRequest(Action<T, ApiLinksFormat> onSuccess, Action<float> onProgress, Action<ApiErrorFormat> onError)
        {
            if (onProgress != null)
            {
                OnDownloadProgress = onProgress;
            }
            RequestCommon(
                onSuccess: (response) => ResponseConverter.Convert(
                    response,
                    (responseTemplate) => onSuccess(responseTemplate.data, responseTemplate._links),
                    onError
                ),
                onError: onError
            );
        }

        /// <summary>
        /// Apiへのリクエストを実行する
        /// </summary>
        /// <remarks>
        /// アクセストークンが切れていた場合は自動でリフレッシュして再度リクエストする
        /// </remarks>
        /// <param name="onSuccess">APIへのリクエストに成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <typeparam name="T">成功した時の戻り値の型</typeparam>
        public void SendRequest(Action<T> onSuccess, Action<ApiErrorFormat> onError)
        {
            SendRequest((data, links) => onSuccess(data), onError);
        }

        /// <summary>
        /// Apiへのリクエストを実行する
        /// </summary>
        /// <remarks>
        /// アクセストークンが切れていた場合は自動でリフレッシュして再度リクエストする
        /// </remarks>
        /// <param name="onSuccess">APIへのリクエストに成功した時のコールバック</param>
        /// <param name="onProgress">APIリクエスト中のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <typeparam name="T">成功した時の戻り値の型</typeparam>
        public void SendRequest(Action<T> onSuccess, Action<float> onProgress, Action<ApiErrorFormat> onError)
        {
            SendRequest(
                onSuccess: (data, links) => onSuccess(data),
                onProgress: onProgress,
                onError: onError
            );
        }

        private void RequestCommon(Action<IWebResponse> onSuccess, Action<ApiErrorFormat> onError)
        {
            AuthorizedRequest(
                onSuccess: onSuccess,
                onError: (error) =>
                {
                    if (error.Response.StatusCode == 401)
                    {
                        RefreshAndRetry(onSuccess, onError);
                    }
                    else
                    {
                        convertErrorResponse(error.Response, onError);
                    }
                }
            );
        }

        private void AuthorizedRequest(Action<IWebResponse> onSuccess, Action<HttpRequestFailException> onError)
        {
            var conn = Authenticate.CreateAuthorizedHttpConnection(
                requestPath: RequestPath,
                param: Params,
                methods: Methods,
                headers: Headers
            );

            if (onSuccess != null)
            {
                conn.OnSuccess = (response) => onSuccess(response);
            }
            if (OnDownloadProgress != null)
            {
                conn.OnDownloadProgress = (progress) => OnDownloadProgress(progress);
            }
            if (OnUploadProgress != null)
            {
                conn.OnUploadProgress = (progress) => OnUploadProgress(progress);
            }
            if (onError != null)
            {
                conn.OnError = (error) => onError(error);
            }
            conn.RequestAsync(Timeout);
        }

        private void convertErrorResponse(IWebResponse response, Action<ApiErrorFormat> onError)
        {
            onError(ResponseConverter.ConvertError(response));
        }

        private void RefreshAndRetry(Action<IWebResponse> onSuccess, Action<ApiErrorFormat> onError)
        {
            Authenticate.RefreshExistAccountForce(
                (bool isAuthSuccess) =>
                {
                    if (isAuthSuccess)
                    {
                        AuthorizedRequest(
                            onSuccess: onSuccess,
                            onError: (error) => convertErrorResponse(error.Response, onError)
                        );
                    }
                    else
                    {
                        if (onError != null)
                        {
                            onError(new ApiErrorFormat()
                            {
                                code = "AUTHORIZED_ERROR",
                                message = "Authorize Request Fail"
                            });
                        }
                    }
                },
                (HttpRequestFailException e) =>
                {
                    if (onError != null)
                    {
                        onError(new ApiErrorFormat()
                        {
                            code = "UNKNOWN_ERROR",
                            message = e.Message
                        });
                    }
                }
            );
        }
    }
}
