using VRoidSDK.Examples.Core.View.Parts;
using System.Collections.Generic;
using UnityEngine;
using Component = VRoidSDK.Examples.Core.View.Component;

namespace VRoidSDK.Examples.ArtworkExample.View
{
    public class ArtworksDetailView : Component
    {
        public VerticalScrollGroup artworkMediumScrollRoot;
        public Button closeButton;

        public void SetArtworkMedia(List<ArtworkMedium> media)
        {
            artworkMediumScrollRoot.Insert<ArtworkMedium, ArtworkMediumImage>(media, null);
        }
    }
}
