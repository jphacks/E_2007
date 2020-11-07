using System;
using UnityEngine;
using VRoidSDK.Networking;

namespace VRoidSDK
{
    /// <summary>
    /// WebResponseをバイト配列に加工するメソッドを提供するクラス
    /// </summary>
    public class ByteResponseConverter : ResponseConverterBase<byte[]>
    {
        /// <summary>
        /// WebResponseをバイト配列のデータに変換する
        /// </summary>
        /// <param name="response">変換するWebResponse</param>
        /// <param name="onSuccess">変換に成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        public override void Convert(IWebResponse response, Action<ApiResponseTemplate<byte[]>> onSuccess, Action<ApiErrorFormat> onError)
        {
            if (onSuccess != null)
            {
                onSuccess(new ApiResponseTemplate<byte[]>()
                {
                    data = response.Data,
                    error = new ApiErrorFormat(),
                    _links = new ApiLinksFormat(),
                });
            }
        }
    }
}
