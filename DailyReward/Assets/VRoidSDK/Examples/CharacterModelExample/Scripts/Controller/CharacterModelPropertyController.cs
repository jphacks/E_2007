using System;
using VRoidSDK.Examples.Core.Controller;
using VRoidSDK.Examples.Core.Renderer;
using VRoidSDK.Examples.CharacterModelExample.Model;
using VRoidSDK.Examples.CharacterModelExample.Renderer;

namespace VRoidSDK.Examples.CharacterModelExample.Controller
{
    public class CharacterModelPropertyController : BaseController
    {
        private LoginController _login;
        private CharacterModelPropertyModel _model;

        public CharacterModelPropertyController(LoginController login)
        {
            _model = new CharacterModelPropertyModel();
            _login = login;
        }

        public void GetCharacterModelProperty(CharacterModel characterModel, Action<IRenderer> onResponse)
        {
            CheckLogin(_login, onResponse, (_) =>
            {
                HubApi.GetCharacterModelsProperty(characterModel.id,
                    (property) => _model.CharacterModelProperty = property,
                    (error) =>
                    {
                        _model.ApiError = error;
                        onResponse(new ApiErrorRenderer(_model));
                    });
            });
        }

        public void ShowCharacterModelProperty(Action<IRenderer> onResponse)
        {
            _model.Active = true;
            onResponse(new CharacterModelPropertyRenderer(_model));
        }

        public void HideCharacterModelProperty(Action<IRenderer> onResponse)
        {
            _model.Active = false;
            onResponse(new CharacterModelPropertyRenderer(_model));
        }
    }
}
