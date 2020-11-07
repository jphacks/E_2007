using VRoidSDK.Examples.Core.View.Parts;
using Component = VRoidSDK.Examples.Core.View.Component;

namespace VRoidSDK.Examples.CharacterModelExample.View
{
    public class CharacterModelDownloadView : Component
    {
        public LoadImage characterModelIcon;
        public Message characterName;
        public Message characterModelName;
        public Message characterModelPublisherName;
        public ProgressBar downloadProgress;
        public Message loadingMessage;
        public ButtonGroup buttonGroup;
    }
}
