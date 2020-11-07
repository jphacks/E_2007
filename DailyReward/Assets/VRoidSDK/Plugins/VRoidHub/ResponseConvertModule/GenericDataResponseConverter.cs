using System;
using UnityEngine;
using Newtonsoft.Json;
using VRoidSDK.Networking;

namespace VRoidSDK
{
    /// <summary>
    /// WebResponseをDataModelに加工するメソッドを提供するクラス
    /// </summary>
    public class GenericDataResponseConverter<T> : ResponseConverterBase<T>
    {
        /// <summary>
        /// WebResponseを指定したDataModelに変換する
        /// </summary>
        /// <param name="response">変換するWebResponse</param>
        /// <param name="onSuccess">変換に成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <typeparam name="T">成功した時の戻り値の型</typeparam>
        public override void Convert(IWebResponse response, Action<ApiResponseTemplate<T>> onSuccess, Action<ApiErrorFormat> onError)
        {
            if (onSuccess == null)
            {
                return;
            }

            ApiResponseTemplate<T> templateJson;

            try
            {
                templateJson = JsonConvert.DeserializeObject<ApiResponseTemplate<T>>(response.Text);
            }
            catch (Exception e)
            {
                if (onError != null)
                {
                    onError(new ApiErrorFormat()
                    {
                        code = "JSON_DESERIALIZE_ERROR",
                        message = e.Message
                    });
                }
                return;
            }
            onSuccess(templateJson);
        }
    }
}
