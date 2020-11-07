using UnityEngine;
using VRoidSDK.Examples.Core.View;
using VRoidSDK.Examples.Core.Renderer;
using VRoidSDK.Examples.Core.Localize;
using VRoidSDK.Examples.ArtworkExample.View;
using VRoidSDK.Examples.ArtworkExample.Model;

namespace VRoidSDK.Examples.ArtworkExample.Renderer
{
    public class ArtworkCreateRenderer : IRenderer
    {
        private bool _panelActive;
        private Texture2D _screenShot;
        private bool _uploadProgressActive;
        private float _progress;
        private bool _isSimulation;

        public ArtworkCreateRenderer(ArtworkUploadModel model)
        {
            _panelActive = model.Active;
            _screenShot = model.ScreenShot;
            _uploadProgressActive = model.UploadProgressActive;
            _progress = model.Progress;
            _isSimulation = model.SimulateMode;
        }

        public void Rendering(RootView root)
        {
            var artworkView = (ArtworkRootView)root;
            artworkView.ApiErrorMessage.Active = false;
            artworkView.artworkCreateMenuView.Active = _panelActive;
            artworkView.artworkCreateMenuView.image.Load(_screenShot);

            if (_panelActive)
            {
                artworkView.artworkCreateMenuView.headerTitle.Text = Translator.Lang.Get(ExampleViewKey.ViewArtworkCreateTitle);
                artworkView.artworkCreateMenuView.caption.Text = Translator.Lang.Get(ExampleViewKey.ViewArtworkCreateCaption);
                artworkView.artworkCreateMenuView.ageLimit.Text = Translator.Lang.Get(ExampleViewKey.ViewArtworkCreateAgeLimit);
                artworkView.artworkCreateMenuView.ageLimitAll.Text = Translator.Lang.Get(ExampleViewKey.ViewArtworkCreateAgeLimitAll);
                artworkView.artworkCreateMenuView.ageLimitR15.Text = Translator.Lang.Get(ExampleViewKey.ViewArtworkCreateAgeLimitR15);
                artworkView.artworkCreateMenuView.ageLimitR18.Text = Translator.Lang.Get(ExampleViewKey.ViewArtworkCreateAgeLimitR18);
                artworkView.artworkCreateMenuView.uploadButton.Message.Text = Translator.Lang.Get(ExampleViewKey.ViewArtworkCreateUpload);
                artworkView.artworkCreateMenuView.cancelButton.Message.Text = Translator.Lang.Get(ExampleViewKey.ViewArtworkCreateCancel);
            }

            if (_uploadProgressActive)
            {
                artworkView.artworkCreateMenuView.uploadButton.Active = false;
                artworkView.artworkCreateMenuView.cancelButton.Active = false;
                artworkView.artworkCreateMenuView.progressBar.Active = true;
            }
            else
            {
                artworkView.artworkCreateMenuView.uploadButton.Active = true;
                artworkView.artworkCreateMenuView.cancelButton.Active = true;
                artworkView.artworkCreateMenuView.progressBar.Active = false;
            }

            artworkView.artworkCreateMenuView.progressBar.Value = _progress;
            artworkView.artworkCreateMenuView.simulationLabel.Active = _isSimulation;

            if (_isSimulation)
            {
                artworkView.artworkCreateMenuView.simulationLabel.Text = Translator.Lang.Get(ExampleViewKey.ViewArtworkCreateSimulation);
            }
        }
    }
}
