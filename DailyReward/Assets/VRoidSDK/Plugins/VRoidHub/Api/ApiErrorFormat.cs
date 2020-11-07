using System.Collections.Generic;

namespace VRoidSDK
{
    /// <summary>
    /// VRoid HubApiへリクエストした時のエラー情報
    /// </summary>
    public struct ApiErrorFormat
    {
        /// <summary>
        /// エラーコード
        /// </summary>
        public string code;

        /// <summary>
        /// 発生したエラーに関するメッセージ
        /// </summary>
        public string message;

        /// <summary>
        /// エラーの詳細
        /// </summary>
        public Dictionary<string, object> details;
    }
}
