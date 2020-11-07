using System;
using UnityEngine;
using Newtonsoft.Json;
using VRoidSDK.Networking;

namespace VRoidSDK
{
    /// <summary>
    /// WebResponseを加工するメソッドを提供するインターフェース
    /// </summary>
    abstract public class ResponseConverterBase<T>
    {
        /// <summary>
        /// WebResponseを指定した型に変換する
        /// </summary>
        /// <param name="response">変換するWebResponse</param>
        /// <param name="onSuccess">変換に成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <typeparam name="T">成功した時の戻り値の型</typeparam>
        abstract public void Convert(IWebResponse response, Action<ApiResponseTemplate<T>> onSuccess, Action<ApiErrorFormat> onError);

        /// <summary>
        /// WebResponseをApiErrorFormatに変換する
        /// </summary>
        /// <param name="response">変換するWebResponse</param>
        /// <returns>変換後のApiErrorFormat</returns>
        public ApiErrorFormat ConvertError(IWebResponse response)
        {
            if (response.IsNetworkError)
            {
                return new ApiErrorFormat()
                {
                    code = "NETWORK_ERROR",
                    message = response.RawErrorMessage
                };
            }
            else if (response.IsHttpError)
            {
                try
                {
                    ApiResponseTemplate<EmptySerializer> templateJson = JsonConvert.DeserializeObject<ApiResponseTemplate<EmptySerializer>>(response.Text);
                    return templateJson.error;
                }
                catch
                {
                    return new ApiErrorFormat()
                    {
                        code = "HTTP_ERROR",
                        message = "An HTTP error occurred. Status code: " + response.StatusCode.ToString()
                    };
                }
            }
            else
            {
                return new ApiErrorFormat()
                {
                    code = "UNKNOWN_ERROR",
                    message = "Maybe the request was successful"
                };
            }
        }
    }
}
