using UnityEngine;
using VRoidSDK.OAuth;
using VRoidSDK.Examples.Core.View;
using VRoidSDK.Examples.Core.Renderer;
using VRoidSDK.Examples.Core.Controller;
using VRoidSDK.Examples.Core.Localize;
using VRoidSDK.Examples.CharacterModelExample.View;
using VRoidSDK.Examples.CharacterModelExample.Controller;
using VRoidSDK.Examples.CharacterModelExample.Model;

namespace VRoidSDK.Examples.CharacterModelExample
{
    public class Routes : MonoBehaviour
    {
        [SerializeField] private SDKConfiguration _sdkConfiguration;
        [SerializeField] private CharacterModelRootView _rootView;
        [SerializeField] private CharacterModelExampleEventHandler _eventHandler;

        private LoginController _loginController;
        private CharacterModelsController _characterModelsController;
        private CharacterModelDetailController _characterModelDetailController;
        private CharacterModelDownloadController _characterModelDownloadController;
        private LoadedCharacterModelController _loadedCharacterModelController;
        private CharacterModelPropertyController _characterModelPropertyController;

        private void Start()
        {
            Authentication.Instance.Init(_sdkConfiguration.AuthenticateMetaData);
            _loginController = new LoginController(Authentication.Instance, _sdkConfiguration);
            _characterModelsController = new CharacterModelsController(_loginController);
            _characterModelDownloadController = new CharacterModelDownloadController();
            _characterModelPropertyController = new CharacterModelPropertyController(_loginController);
            _loadedCharacterModelController = new LoadedCharacterModelController(_characterModelPropertyController, _eventHandler);
            _characterModelDetailController = new CharacterModelDetailController(_loginController, _characterModelsController,
                _characterModelDownloadController, _loadedCharacterModelController);
        }

        public void ShowCharacterModels()
        {
            _characterModelsController.ShowCharacterModels(Rendering);
        }

        public void HideCharacterModels()
        {
            _characterModelsController.HideCharacterModels(Rendering);
        }

        public void ShowCharacterModel(CharacterModel model)
        {
            _characterModelDetailController.ShowCharacterModel(model, Rendering);
        }

        public void HideCharacterModel()
        {
            _characterModelDetailController.HideCharacterModel(Rendering);
        }

        public void SeeMore()
        {
            _characterModelsController.ShowNextCharacterModels(Rendering);
        }

        public void CheckAccept(UnityEngine.UI.Toggle toggle)
        {
            var result = toggle.isOn;
            _characterModelDetailController.CheckAccept(result, Rendering);
        }

        public void UseCharacterModel()
        {
            _characterModelDetailController.UseCharacterModel(Rendering);
        }

        public void ChangeTab(int tab)
        {
            _characterModelsController.ChangeTab((CharacterModelsModel.Tab)tab, Rendering);
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
            HideCharacterModels();
        }

        public void Login()
        {
            _loginController.Login(Rendering);
        }

        public void LocalizeChanged(int locale)
        {
            var translateLocale = (Translator.Locales)locale;
            Translator.ChangeTo(translateLocale);
            if (_eventHandler)
            {
                _eventHandler.OnLangChanged(translateLocale);
            }
        }

        public void HideDownloadModel()
        {
            _characterModelDownloadController.Close(Rendering);
        }

        public void ShowLoadedCharacterModel()
        {
            _loadedCharacterModelController.ShowLoadedCharacterModel(Rendering);
        }

        public void ShowCharacterModelProperty()
        {
            _characterModelPropertyController.ShowCharacterModelProperty(Rendering);
        }

        public void HideCharacterModelProperty()
        {
            _characterModelPropertyController.HideCharacterModelProperty(Rendering);
        }

        private void Rendering(IRenderer renderer)
        {
            renderer.Rendering(_rootView);
        }
    }
}
