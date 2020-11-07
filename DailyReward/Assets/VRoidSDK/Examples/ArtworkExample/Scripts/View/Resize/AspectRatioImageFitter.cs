using UnityEngine;
using UnityEngine.UI;
using VRoidSDK.Examples.Core.View.Resize;

namespace VRoidSDK.Examples.ArtworkExample.View.Resize
{
    public class AspectRatioImageFitter : LoadImageFitter
    {
        public override void Fit(RawImage image, Texture2D texture)
        {
            image.SetNativeSize();
            var aspectRatio = texture.texelSize.y / texture.texelSize.x;
            image.GetComponent<AspectRatioFitter>().aspectRatio = aspectRatio;
        }
    }
}
