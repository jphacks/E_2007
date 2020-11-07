using System.Collections.Generic;
using VRoidSDK.Examples.Core.View.Parts;
using UnityEngine;
using Component = VRoidSDK.Examples.Core.View.Component;

namespace VRoidSDK.Examples.ArtworkExample.View
{
    public class ArtworksView : Component
    {
        [SerializeField] private Routes _routes;

        public VerticalScrollGroup userArtworksScrollRoot;
        public LoadImage userArtworksUserIcon;
        public Button seeMoreButton;

        public void SetUserIcon(WebImage icon)
        {
            userArtworksUserIcon.Load(icon);
        }

        public void SetArtworkThumbnails(List<Artwork> artworks)
        {
            userArtworksScrollRoot.Insert<Artwork, ArtworkThumbnail>(artworks, (artwork) =>
            {
                _routes.ShowArtwork(artwork.Artwork.id);
            });
        }
    }
}
