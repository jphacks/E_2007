using VRoidSDK.Examples.Core.View;
using VRoidSDK.Examples.Core.Model;
using VRoidSDK.Examples.Core.Localize;

namespace VRoidSDK.Examples.Core.Renderer
{
    public class LoginViewRenderer : IRenderer
    {
        private bool _panelActive;
        private LoginModel.State _authorizedState;
        private string _currentUserName;
        private WebImage _currentUserIcon;

        public LoginViewRenderer(LoginModel model)
        {
            _panelActive = model.Active;
            _authorizedState = model.AuthorizationState;
            if (model.CurrentUser != null)
            {
                _currentUserName = model.CurrentUser.Value.user_detail.user.name;
                _currentUserIcon = model.CurrentUser.Value.user_detail.user.icon.sq170;
            }
        }

        public void Rendering(RootView root)
        {
            root.ApiErrorMessage.Active = false;

            if (_panelActive)
            {
                root.loginView.Active = true;
            }

            switch (_authorizedState)
            {
                case LoginModel.State.AUTHORIZED:
                    root.loginView.loginConnectButton.Active = false;
                    root.loginView.logoutButton.Active = true;
                    root.loginView.logoutButton.Message.Text = Translator.Lang.Get(ExampleViewKey.ViewLoginLogout);
                    root.loginView.codeField.Active = false;
                    root.loginView.loginButton.Active = false;
                    root.loginView.loginConnectButton.Active = false;
                    root.loginView.connectionFailureMessageText.Active = false;
                    root.loginView.loginFailureMessageText.Active = false;

                    if (_currentUserName != null)
                    {
                        root.loginView.accountInfo.Active = true;
                        root.loginView.accountInfo.Set(_currentUserName, _currentUserIcon);
                    }
                    break;
                case LoginModel.State.NOT_AUTHORIZED:
                    root.loginView.loginConnectButton.Active = false;
                    root.loginView.logoutButton.Active = false;
                    root.loginView.accountInfo.Active = false;
                    root.loginView.codeField.Active = false;
                    root.loginView.loginButton.Active = false;
                    root.loginView.loginConnectButton.Active = true;
                    root.loginView.loginConnectButton.Message.Text = Translator.Lang.Get(ExampleViewKey.ViewLoginLoginConnect);
                    root.loginView.connectionFailureMessageText.Active = false;
                    root.loginView.loginFailureMessageText.Active = false;
                    break;
                case LoginModel.State.AUTHORIZATION_CODE_REQUESTED:
                    root.loginView.loginConnectButton.Active = false;
                    root.loginView.logoutButton.Active = false;
                    root.loginView.accountInfo.Active = false;
                    root.loginView.codeField.Active = true;
                    root.loginView.codeField.Label.Text = Translator.Lang.Get(ExampleViewKey.ViewLoginAuthorizationCode);
                    root.loginView.loginButton.Active = true;
                    root.loginView.loginButton.Message.Text = Translator.Lang.Get(ExampleViewKey.ViewLoginLogin);
                    root.loginView.loginConnectButton.Active = false;
                    root.loginView.connectionFailureMessageText.Active = false;
                    root.loginView.loginFailureMessageText.Active = false;
                    break;
                case LoginModel.State.CONNECTION_FAILED:
                    root.loginView.loginConnectButton.Active = false;
                    root.loginView.logoutButton.Active = false;
                    root.loginView.accountInfo.Active = false;
                    root.loginView.codeField.Active = false;
                    root.loginView.loginButton.Active = false;
                    root.loginView.loginConnectButton.Active = true;
                    root.loginView.loginConnectButton.Message.Text = Translator.Lang.Get(ExampleViewKey.ViewLoginLoginConnect);
                    root.loginView.connectionFailureMessageText.Active = true;
                    root.loginView.connectionFailureMessageText.Text = Translator.Lang.Get(ExampleViewKey.ViewLoginConnectionFailureMessage);
                    root.loginView.loginFailureMessageText.Active = false;
                    break;
                case LoginModel.State.REQUEST_FAILED:
                    root.loginView.loginConnectButton.Active = false;
                    root.loginView.logoutButton.Active = false;
                    root.loginView.accountInfo.Active = false;
                    root.loginView.codeField.Active = false;
                    root.loginView.loginButton.Active = false;
                    root.loginView.loginConnectButton.Active = true;
                    root.loginView.loginConnectButton.Message.Text = Translator.Lang.Get(ExampleViewKey.ViewLoginLoginConnect);
                    root.loginView.connectionFailureMessageText.Active = false;
                    root.loginView.loginFailureMessageText.Active = true;
                    root.loginView.loginFailureMessageText.Text = Translator.Lang.Get(ExampleViewKey.ViewLoginLoginFailureMessage);
                    break;
                default:
                    break;
            }

            if (!_panelActive)
            {
                root.loginView.Active = false;
            }
        }
    }
}
