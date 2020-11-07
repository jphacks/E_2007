using System;
using VRoidSDK.Examples.Core.Renderer;

namespace VRoidSDK.Examples.Core.Controller
{
    public class BaseController
    {
        public void CheckLogin(LoginController login, Action<IRenderer> onResponse, Action<Account> onLoggedIn)
        {
            if (!login.IsAuthorized())
            {
                login.OpenLogin(onResponse);
            }

            login.LoginToVroidHub(onResponse, onLoggedIn);
        }
    }
}
