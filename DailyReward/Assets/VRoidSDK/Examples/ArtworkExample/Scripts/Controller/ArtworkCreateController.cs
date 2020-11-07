using System;
using System.Collections.Generic;
using VRoidSDK.Examples.Core.Controller;
using VRoidSDK.Examples.Core.Renderer;
using VRoidSDK.Examples.ArtworkExample.Renderer;
using VRoidSDK.Examples.ArtworkExample.Model;

namespace VRoidSDK.Examples.ArtworkExample.Controller
{
    public class ArtworkCreateController : BaseController
    {
        private LoginController _login;
        private ArtworkUploadModel _model;

        public ArtworkCreateController(LoginController login)
        {
            _login = login;
            _model = new ArtworkUploadModel();
        }

        public void CreateArtwork(UnityEngine.Texture2D texture, bool simulateMode, Action<IRenderer> onResponse)
        {
            CheckLogin(_login, onResponse, (account) =>
            {
                _model.Active = true;
                _model.ScreenShot = texture;
                _model.SimulateMode = simulateMode;
                onResponse(new ArtworkCreateRenderer(_model));
            });
        }

        public void HideCreateArtwork(Action<IRenderer> onResponse)
        {
            _model.Active = false;
            onResponse(new ArtworkCreateRenderer(_model));
        }

        public void UpdateCaption(string caption)
        {
            _model.Caption = caption;
        }

        public void UpdateAgeLimit(EnumAgeLimit limit, bool changeTo)
        {
            if (changeTo == false) return;
            _model.AgeLimit = limit;
        }

        public void UploadArtwork(Action<IRenderer> onResponse)
        {
            CheckLogin(_login, onResponse, (_) =>
            {
                // シミュレーションモードのときはアップロードを行わない
                if (_model.SimulateMode)
                {
                    _model.Progress = 1.0f;
                    _model.UploadProgressActive = false;
                    _model.Active = false;
                    onResponse(new ArtworkCreateRenderer(_model));
                    return;
                }
                _model.UploadProgressActive = true;
                onResponse(new ArtworkCreateRenderer(_model));

                var png = UnityEngine.ImageConversion.EncodeToPNG(_model.ScreenShot);
                var param = new PostArtworkMediaImagesParams(png);

                HubApi.PostArtworkMediaImage(param, (medium) =>
                {
                    var artworkMedia = new List<string> { medium.id };
                    var artworksParams = new PostArtworksParams(_model.Caption, _model.AgeLimit, artworkMedia);
                    HubApi.PostArtwork(artworksParams, (artworkDetail) =>
                    {
                        _model.Progress = 1.0f;
                        _model.UploadProgressActive = false;
                        _model.Active = false;
                        onResponse(new ArtworkCreateRenderer(_model));
                        UnityEngine.Application.OpenURL(HubRouteUri.Artwork(artworkDetail.artwork).ToString());
                    }, (error) =>
                    {
                        _model.Progress = 0.0f;
                        _model.UploadProgressActive = false;
                        _model.Active = false;
                        onResponse(new ArtworkCreateRenderer(_model));
                        _model.ApiError = error;
                        onResponse(new ApiErrorRenderer(_model));
                    });
                }, (progress) =>
                {
                    _model.Progress = progress;
                    onResponse(new ArtworkCreateRenderer(_model));
                }, (error) =>
                {
                    _model.UploadProgressActive = false;
                    onResponse(new ArtworkCreateRenderer(_model));
                    _model.ApiError = error;
                    onResponse(new ApiErrorRenderer(_model));
                });
            });
        }
    }
}
