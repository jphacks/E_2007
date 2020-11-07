using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace VRoidSDK
{
    /// <summary>
    /// VRoid HubのAPIをリクエストしてDataModelで受け取るためのクラス
    /// </summary>
    /// <typeparam name="T">リクエスト結果の型</typeparam>
    public class GenericDataRequest<T> : ApiRequestBase<T>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="requestPath">リクエストするAPIのURL</param>
        public GenericDataRequest(string requestPath) : base(requestPath)
        {
            ResponseConverter = new GenericDataResponseConverter<T>();
        }
    }
}
