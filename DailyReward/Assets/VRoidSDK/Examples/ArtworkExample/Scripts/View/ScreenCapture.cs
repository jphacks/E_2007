using System;
using UnityEngine;
using VRoidSDK.Examples.Core.View;
using Component = VRoidSDK.Examples.Core.View.Component;

namespace VRoidSDK.Examples.ArtworkExample.View
{
    public class ScreenCapture : Component
    {
        private bool _grab = false;
        private Action<Texture2D> _onCapture;

        public void Capture(Action<Texture2D> onCapture)
        {
            _onCapture = onCapture;
            _grab = true;
        }

        private void OnPostRender()
        {
            if (!_grab)
            {
                return;
            }

            var texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
            texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
            texture.Apply();
            _grab = false;

            if (_onCapture != null)
            {
                _onCapture(texture);
            }
        }
    }
}
