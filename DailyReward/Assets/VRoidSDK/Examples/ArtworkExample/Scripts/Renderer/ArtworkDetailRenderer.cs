using System.Collections.Generic;
using VRoidSDK.Examples.Core.View;
using VRoidSDK.Examples.Core.Renderer;
using VRoidSDK.Examples.Core.Localize;
using VRoidSDK.Examples.ArtworkExample.View;
using VRoidSDK.Examples.ArtworkExample.Model;

namespace VRoidSDK.Examples.ArtworkExample.Renderer
{
    public class ArtworkDetailRenderer : IRenderer
    {
        private bool _panelActive;
        private ArtworkDetail _artworkDetail;

        public ArtworkDetailRenderer(ArtworkDetailModel model)
        {
            _panelActive = model.Active;
            _artworkDetail = model.ArtworkDetail;
        }

        public void Rendering(RootView root)
        {
            var artworkRoot = (ArtworkRootView)root;
            artworkRoot.ApiErrorMessage.Active = false;
            artworkRoot.overlay.Active = _panelActive;
            artworkRoot.detailView.Active = _panelActive;

            if (_panelActive)
            {
                artworkRoot.detailView.SetArtworkMedia(_artworkDetail.media);
                artworkRoot.detailView.closeButton.Message.Text = Translator.Lang.Get(ExampleViewKey.ViewArtworkDetailCloseButton);
            }
        }
    }
}
