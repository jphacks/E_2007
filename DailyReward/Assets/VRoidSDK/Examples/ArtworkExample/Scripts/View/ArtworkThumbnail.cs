using UnityEngine;
using VRoidSDK.Examples.Core.View.Parts;

namespace VRoidSDK.Examples.ArtworkExample.View
{
    public class ArtworkThumbnail : VerticalScrollItem<Artwork>
    {
        [SerializeField] private LoadImage _image;

        public Artwork Artwork { get; private set; }

        public override void Init(Artwork baseData)
        {
            Artwork = baseData;
            var webImage = baseData.primary_medium.type == EnumArtworkMediumType.image ? baseData.primary_medium.image.sq300 : CreateYoutubeThumbnail(baseData.primary_medium.youtube);
            _image.Load(webImage);
        }

        private WebImage CreateYoutubeThumbnail(ArtworkYoutube youtube)
        {
            return new WebImage
            {
                url = "https://img.youtube.com/vi/" + youtube.youtube_video_id + "/hqdefault.jpg"
            };
        }
    }
}
