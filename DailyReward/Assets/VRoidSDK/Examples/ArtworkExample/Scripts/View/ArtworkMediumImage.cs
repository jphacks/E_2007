using VRoidSDK.Examples.Core.View.Parts;
using UnityEngine;

namespace VRoidSDK.Examples.ArtworkExample.View
{
    public class ArtworkMediumImage : VerticalScrollItem<ArtworkMedium>
    {
        [SerializeField] private LoadImage _image;

        public override void Init(ArtworkMedium artworkMedium)
        {
            var webImage = artworkMedium.type == EnumArtworkMediumType.image ? artworkMedium.image.shrinked1200x1200 : CreateYoutubeThumbnail(artworkMedium.youtube);
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
