using System;

namespace VRoidSDK
{
    /// <summary>
    /// VRoid HubApiへリクエストした時のエラー情報を持つException
    /// </summary>
    public class ApiRequestFailException : Exception
    {
        public ApiErrorFormat Error { get; private set; }
        public ApiRequestFailException(ApiErrorFormat error) : base(error.message)
        {
            Error = error;
        }
    }
}
