using System.Collections.Generic;
using VRoidSDK.Examples.Core.Model;
using UnityEngine;

namespace VRoidSDK.Examples.ArtworkExample.Model
{
    public class ArtworkModel : ApplicationModel
    {
        public List<Artwork> UserArtworks { get; set; }
        public Account? CurrentUser { get; set; }
        public Texture2D ScreenShot { get; set; }
        public EnumAgeLimit AgeLimit { get; set; }
        public ApiLinksFormat Next { get; set; }
        public bool UploadProgressActive { get; set; }
        public float Progress { get; set; }

        public ArtworkModel()
        {
            UserArtworks = new List<Artwork>();
            AgeLimit = EnumAgeLimit.normal;
        }

        public void SetArtworks(List<Artwork> artworks)
        {
            UserArtworks = artworks;
        }

        public void MergeArtworks(List<Artwork> artworks)
        {
            UserArtworks.AddRange(artworks);
        }

        public void CleanArtworks()
        {
            UserArtworks.Clear();
        }
    }
}
