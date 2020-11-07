using System;
using System.Collections.Generic;
using VRoidSDK.Examples.Core.Controller;
using VRoidSDK.Examples.Core.Renderer;
using VRoidSDK.Examples.ArtworkExample.Renderer;
using VRoidSDK.Examples.ArtworkExample.Model;

namespace VRoidSDK.Examples.ArtworkExample.Controller
{
    public class ArtworksController : BaseController
    {
        private LoginController _login;
        private ArtworkModel _model;

        public ArtworksController(LoginController login)
        {
            _login = login;
            _model = new ArtworkModel();
        }

        public void ShowArtworks(Action<IRenderer> onResponse)
        {
            CheckLogin(_login, onResponse, (account) =>
            {
                _model.CurrentUser = account;
                _model.Active = true;
                var user = account.user_detail.user;
                HubApi.GetUsersArtworks(user, 10, (artworks, link) =>
                {
                    _model.SetArtworks(artworks);
                    _model.Next = link;
                    onResponse(new ArtworksRenderer(_model));
                }, (error) =>
                {
                    _model.ApiError = error;
                    onResponse(new ApiErrorRenderer(_model));
                });
            });
        }

        public void ShowNextArtworks(Action<IRenderer> onResponse)
        {
            CheckLogin(_login, onResponse, (account) =>
            {
                _model.Next.next.Value.RequestLink<List<Artwork>>((artworks, link) =>
                {
                    _model.MergeArtworks(artworks);
                    _model.Next = link;
                    onResponse(new ArtworksRenderer(_model));
                }, (error) =>
                {
                    _model.ApiError = error;
                    onResponse(new ApiErrorRenderer(_model));
                });
            });
        }

        public void HideArtworks(Action<IRenderer> onResponse)
        {
            _model.Active = false;
            onResponse(new ArtworksRenderer(_model));
        }
    }
}
