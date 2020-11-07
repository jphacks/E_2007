using System;
using System.Collections.Generic;
using System.Linq;
using VRoidSDK;
using VRoidSDK.Examples.Core.Controller;
using VRoidSDK.Examples.Core.Renderer;
using VRoidSDK.Examples.CharacterModelExample.Model;
using VRoidSDK.Examples.CharacterModelExample.Renderer;

namespace VRoidSDK.Examples.CharacterModelExample.Controller
{
    public class CharacterModelDetailController : BaseController
    {
        private LoginController _login;
        private CharacterModelDetailModel _model;
        private CharacterModelsController _characterModelsController;
        private LoadedCharacterModelController _loadedCharacterModelController;
        private CharacterModelDownloadController _characterModelDownloadController;

        public CharacterModelDetailController(LoginController login, CharacterModelsController characterModelsController,
            CharacterModelDownloadController characterModelDownloadController, LoadedCharacterModelController modelController)
        {
            _login = login;
            _model = new CharacterModelDetailModel();
            _characterModelsController = characterModelsController;
            _loadedCharacterModelController = modelController;
            _characterModelDownloadController = characterModelDownloadController;
        }

        public void ShowCharacterModel(CharacterModel characterModel, Action<IRenderer> onResponse)
        {
            _model.CharacterModel = characterModel;
            if (characterModel.character.user.id == _login.GetLoggedInUserId())
            {
                _characterModelDownloadController.OpenWithoutAccept(characterModel, onResponse);
            }
            else
            {
                _model.IsLicenseAccepted = false;
                _model.Active = true;
                onResponse(new CharacterModelDetailRenderer(_model));
            }
        }

        public void CheckAccept(bool toggle, Action<IRenderer> onResponse)
        {
            _model.IsLicenseAccepted = toggle;
            onResponse(new CharacterModelDetailRenderer(_model));
        }

        public void UseCharacterModel(Action<IRenderer> onResponse)
        {
            CheckLogin(_login, onResponse, (_) =>
            {
                if (_model.CharacterModel == null) return;

                _characterModelDownloadController.Open(_model.CharacterModel.Value, onResponse);
                _model.Active = false;
                onResponse(new CharacterModelDetailRenderer(_model));

                HubModelDeserializer.Instance.LoadCharacterAsync(_model.CharacterModel.Value, (go) =>
                {
                    _characterModelDownloadController.Close(onResponse);
                    _loadedCharacterModelController.SetLoadedModel(_model.CharacterModel.Value, go, onResponse);
                    _characterModelsController.HideCharacterModels(onResponse);
                    _model.CharacterModel = null;
                }, (progress) => _characterModelDownloadController.SeekTo(progress, onResponse), (error) =>
                {
                    _model.ApiError = new ApiErrorFormat()
                    {
                        message = error.Message
                    };
                    onResponse(new ApiErrorRenderer(_model));
                    _characterModelDownloadController.Close(onResponse);
                });
            });
        }

        public void HideCharacterModel(Action<IRenderer> onResponse)
        {
            _model.CharacterModel = null;
            _model.Active = false;
            onResponse(new CharacterModelDetailRenderer(_model));
        }

        private Action<ApiErrorFormat> GetOnErrorCallback(Action<IRenderer> onResponse)
        {
            return (error) =>
            {
                _model.ApiError = error;
                onResponse(new ApiErrorRenderer(_model));
            };
        }
    }
}
