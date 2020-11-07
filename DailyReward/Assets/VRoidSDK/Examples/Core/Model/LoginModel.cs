
namespace VRoidSDK.Examples.Core.Model
{
    public class LoginModel : ApplicationModel
    {
        public enum State
        {
            AUTHORIZED,
            NOT_AUTHORIZED,
            AUTHORIZATION_CODE_REQUESTED,
            CONNECTION_FAILED,
            REQUEST_FAILED,
        }

        public State AuthorizationState { get; set; }
        public Account? CurrentUser { get; set; }

        public LoginModel()
        {
            AuthorizationState = State.NOT_AUTHORIZED;
            CurrentUser = null;
        }

        public bool IsAuthorized()
        {
            return AuthorizationState == State.AUTHORIZED;
        }

        public void ClearUserInfo()
        {
            AuthorizationState = State.NOT_AUTHORIZED;
            CurrentUser = null;
        }
    }
}
