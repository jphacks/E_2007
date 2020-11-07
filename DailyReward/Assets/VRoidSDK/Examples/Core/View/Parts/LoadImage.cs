using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using VRoidSDK.Examples.Core.View.Cache;

namespace VRoidSDK.Examples.Core.View.Parts
{
    public class LoadImage : Component
    {
        [SerializeField] private RawImage _rawImage;
        [SerializeField] private Resize.LoadImageFitter _fitter;

        public void Load(WebImage image)
        {
            StartCoroutine(LoadWebImage(image));
        }

        public void Load(Texture2D texture)
        {
            _rawImage.color = Color.white;
            _rawImage.texture = texture;
            if (_fitter != null)
            {
                _fitter.Fit(_rawImage, texture);
            }
        }

        private IEnumerator LoadWebImage(WebImage image)
        {
            var textureCache = LoadImageCacheStorage.Instance.Load(image.url);
            if (textureCache != null)
            {
                Load(textureCache);
                yield break;
            }

            WWW www = new WWW(image.url);
            yield return www;
            if (string.IsNullOrEmpty(www.error) && www.texture != null)
            {
                Load(www.texture);
                LoadImageCacheStorage.Instance.Save(image.url, www.texture);
            }
        }
    }
}
