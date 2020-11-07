using System.Collections.Generic;
using VRoidSDK.Examples.Core.View;
using VRoidSDK.Examples.Core.Renderer;
using VRoidSDK.Examples.Core.Localize;
using VRoidSDK.Examples.ArtworkExample.View;
using VRoidSDK.Examples.ArtworkExample.Model;

namespace VRoidSDK.Examples.ArtworkExample.Renderer
{
    public class ArtworksRenderer : IRenderer
    {
        private bool _panelActive;
        private List<Artwork> _artworks;
        private Account? _currentUser;
        private ApiLink? _next;

        public ArtworksRenderer(ArtworkModel model)
        {
            _panelActive = model.Active;
            _artworks = model.UserArtworks;
            _currentUser = model.CurrentUser;
            _next = model.Next.next;
        }

        public void Rendering(RootView root)
        {
            var artworkView = (ArtworkRootView)root;
            artworkView.ApiErrorMessage.Active = false;
            artworkView.artworksView.Active = _panelActive;
            if (_panelActive)
            {
                artworkView.artworksView.SetUserIcon(_currentUser.Value.user_detail.user.icon.sq170);
                artworkView.artworksView.SetArtworkThumbnails(_artworks);
            }

            artworkView.artworksView.seeMoreButton.Active = _next != null;
        }
    }
}
