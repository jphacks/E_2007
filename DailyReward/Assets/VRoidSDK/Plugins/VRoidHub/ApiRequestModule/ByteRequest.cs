using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace VRoidSDK
{
    /// <summary>
    /// VRoid HubのAPIをリクエストしてバイト配列で受け取るためのクラス
    /// </summary>
    public class ByteRequest : ApiRequestBase<byte[]>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="requestPath">リクエストするAPIのURL</param>
        public ByteRequest(string requestPath) : base(requestPath)
        {
            ResponseConverter = new ByteResponseConverter();
        }
    }
}
