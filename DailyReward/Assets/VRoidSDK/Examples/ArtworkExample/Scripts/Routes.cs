using UnityEngine;
using VRoidSDK.OAuth;
using VRoidSDK.Examples.Core.Controller;
using VRoidSDK.Examples.Core.Renderer;
using VRoidSDK.Examples.Core.Localize;
using VRoidSDK.Examples.Core.View.Parts;
using VRoidSDK.Examples.ArtworkExample.View;
using VRoidSDK.Examples.ArtworkExample.Renderer;
using VRoidSDK.Examples.ArtworkExample.Controller;
using ScreenCapture = VRoidSDK.Examples.ArtworkExample.View.ScreenCapture;

namespace VRoidSDK.Examples.ArtworkExample
{
    public class Routes : MonoBehaviour
    {
        [SerializeField] private SDKConfiguration _sdkConfiguration;
        [SerializeField] private ArtworkRootView _rootView;
        [SerializeField] private ArtworkExampleEventHandler _eventHandler;
        [SerializeField] private bool _uploadSimulation;
        [SerializeField] private ScreenCapture _capture;

        private LoginController _loginController;
        private ArtworksController _artworksController;
        private ArtworkDetailController _artworkDetailController;
        private ArtworkCreateController _artworkCreateController;

        private void Start()
        {
            Authentication.Instance.Init(_sdkConfiguration.AuthenticateMetaData);
            _loginController = new LoginController(Authentication.Instance, _sdkConfiguration);
            _artworksController = new ArtworksController(_loginController);
            _artworkDetailController = new ArtworkDetailController(_loginController);
            _artworkCreateController = new ArtworkCreateController(_loginController);
        }

        public void ShowArtworks()
        {
            _artworksController.ShowArtworks(Rendering);
        }

        public void ShowNextArtworks()
        {
            _artworksController.ShowNextArtworks(Rendering);
        }

        public void ShowArtwork(string artworkId)
        {
            _artworkDetailController.ShowArtwork(artworkId, Rendering);
        }

        public void HideArtworks()
        {
            _artworksController.HideArtworks(Rendering);
        }

        public void HideArtwork()
        {
            _artworkDetailController.HideArtwork(Rendering);
        }

        public void SendAuthorizeCode(UnityEngine.UI.InputField code)
        {
            var text = code.text;
            _loginController.SendAuthorizationCode(text);
        }

        public void ShowLoginPanel()
        {
            _loginController.OpenLogin(Rendering);
        }

        public void CloseLoginPanel()
        {
            _loginController.CloseLogin(Rendering);
        }

        public void Logout()
        {
            _loginController.Logout(Rendering);
            HideArtworks();
        }

        public void Login()
        {
            _loginController.Login(Rendering);
        }

        public void ShowArtworkCreateMenu()
        {
            _capture.Capture((texture) =>
            {
                _artworkCreateController.CreateArtwork(texture, _uploadSimulation, Rendering);
            });
        }

        public void HideArtworkCreateMenu()
        {
            _artworkCreateController.HideCreateArtwork(Rendering);
        }

        public void ChangeCaption(UnityEngine.UI.InputField input)
        {
            _artworkCreateController.UpdateCaption(input.text);
        }

        public void ChangeAgeLimit(UnityEngine.UI.Toggle toggle)
        {
            var toggleValue = toggle.GetComponent<ToggleNumericValue>();
            _artworkCreateController.UpdateAgeLimit((EnumAgeLimit)toggleValue.Value, toggle.isOn);
        }

        public void UploadArtwork()
        {
            _artworkCreateController.UploadArtwork(Rendering);
        }

        public void LocalizeChanged(int locale)
        {
            var translateLocale = (Translator.Locales)locale;
            Translator.ChangeTo(translateLocale);

            if (_eventHandler != null)
            {
                _eventHandler.OnLangChanged(translateLocale);
            }
        }

        private void Rendering(IRenderer renderer)
        {
            renderer.Rendering(_rootView);
        }
    }
}
