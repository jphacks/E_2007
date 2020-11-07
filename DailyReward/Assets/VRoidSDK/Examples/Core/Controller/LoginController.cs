using System;
using VRoidSDK.OAuth;
using VRoidSDK.Examples.Core.Renderer;
using VRoidSDK.Examples.Core.Model;

namespace VRoidSDK.Examples.Core.Controller
{
    public class LoginController
    {
        private LoginModel _model;
        private IAuthentication _auth;
        private SDKConfiguration _sdkConfig;
        private BrowserAuthorize _browser;

        public LoginController(IAuthentication auth, SDKConfiguration config)
        {
            _auth = auth;
            _model = new LoginModel();
            _model.AuthorizationState = _auth.IsAuthorized() ? LoginModel.State.AUTHORIZED : LoginModel.State.NOT_AUTHORIZED;
            _sdkConfig = config;
        }

        public bool IsAuthorized()
        {
            return _model.IsAuthorized();
        }

        public string GetLoggedInUserId()
        {
            return _model.CurrentUser.Value.user_detail.user.id;
        }

        public void OpenLogin(Action<IRenderer> onResponse)
        {
            _model.Active = true;
            onResponse(new LoginViewRenderer(_model));
        }

        public void CloseLogin(Action<IRenderer> onResponse)
        {
            _model.Active = false;
            onResponse(new LoginViewRenderer(_model));
        }

        public void Login(Action<IRenderer> onResponse)
        {
            if (_model.IsAuthorized())
            {
                onResponse(new LoginViewRenderer(_model));
                return;
            }

            LoginToVroidHub(onResponse, (account) => UnityEngine.Debug.Log("User LoggedIn Success."));
        }

        public void Logout(Action<IRenderer> onResponse)
        {
            if (!_model.IsAuthorized())
            {
                onResponse(new LoginViewRenderer(_model));
                return;
            }

            _auth.Logout();
            _model.ClearUserInfo();
            onResponse(new LoginViewRenderer(_model));
        }

        public void LoginToVroidHub(Action<IRenderer> onResponse, Action<Account> onLoggedIn)
        {
            if (_model.IsAuthorized())
            {
                GetAccountInfo(onResponse, onLoggedIn);
                return;
            }

            // modelを操作
            _auth.AuthorizeWithExistAccount((bool isSuccess) =>
            {
                if (!isSuccess)
                {
                    _model.AuthorizationState = LoginModel.State.AUTHORIZATION_CODE_REQUESTED;
                    onResponse(new LoginViewRenderer(_model));
                    _browser = BrowserAuthorize.GenerateInstance(_sdkConfig);
                    _browser.OpenBrowser(AfterAuthentication(onResponse, onLoggedIn));
                }
                else
                {
                    _model.AuthorizationState = LoginModel.State.AUTHORIZED;
                    GetAccountInfo(onResponse, onLoggedIn);
                }
            }, (error) =>
            {
                _model.AuthorizationState = LoginModel.State.CONNECTION_FAILED;
                onResponse(new LoginViewRenderer(_model));
            });
        }

        public void SendAuthorizationCode(string code)
        {
            if (_browser)
            {
                _browser.RegisterCode(code);
            }
        }

        private Action<bool> AfterAuthentication(Action<IRenderer> onResponse, Action<Account> onLoggedIn)
        {
            return (authorized) =>
            {
                _model.AuthorizationState = authorized ? LoginModel.State.AUTHORIZED : LoginModel.State.REQUEST_FAILED;
                if (authorized)
                {
                    _model.Active = false;
                    onResponse(new LoginViewRenderer(_model));
                }
                else
                {
                    onResponse(new LoginViewRenderer(_model));
                }
                GetAccountInfo(onResponse, onLoggedIn);
            };
        }

        private void GetAccountInfo(Action<IRenderer> onResponse, Action<Account> onLoggedIn)
        {
            if (_model.CurrentUser != null)
            {
                onLoggedIn(_model.CurrentUser.Value);
                return;
            }

            HubApi.GetAccount((account) =>
            {
                _model.CurrentUser = account;
                _model.Active = false;
                onLoggedIn(account);
            }, (error) =>
            {
                _model.ApiError = error;
                onResponse(new ApiErrorRenderer(_model));
            });
        }
    }
}
