using UnityEngine;

namespace VRoidSDK
{
    internal class AuthenticateSessionDefault : IAuthenticateSession
    {
        public void OpenURL(string url, string urlScheme)
        {
            Application.OpenURL(url);
        }

        public void CleanUp()
        {
        }
    }
}
