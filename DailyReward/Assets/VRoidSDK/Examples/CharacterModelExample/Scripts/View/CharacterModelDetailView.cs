using VRoidSDK.Examples.Core.View.Parts;
using Component = VRoidSDK.Examples.Core.View.Component;

namespace VRoidSDK.Examples.CharacterModelExample.View
{
    public class CharacterModelDetailView : Component
    {
        public LoadImage characterModelIcon;
        public Message characterName;
        public Message characterModelName;
        public Message characterModelPublisherName;
        public Message modelUseConditions;
        public Message canUseAvatar;
        public Message canUseViolence;
        public Message canUseSexuality;
        public Message canUseCorporateCommercial;
        public Message canUsePersonalCommercial;
        public Message canModify;
        public Message canRedistribute;
        public Message showCredit;
        public Button acceptButton;
        public Button retryButton;
        public Button cancelButton;
        public ToggleBox isAccepted;
    }
}
