using System.Runtime.InteropServices;
using UnityEngine;

namespace VRoidSDK
{
#if !UNITY_EDITOR && UNITY_IOS
    internal class AuthenticateSessionIOS : IAuthenticateSession
    {
        [DllImport("__Internal")]
        private static extern void OpenBrowserWindow(string url, string urlScheme);

        [DllImport("__Internal")]
        private static extern void ReleaseSession();

        public void OpenURL(string url, string urlScheme)
        {
            OpenBrowserWindow(url, urlScheme);
        }

        public void CleanUp()
        {
            ReleaseSession();
        }
    }
#endif
}
