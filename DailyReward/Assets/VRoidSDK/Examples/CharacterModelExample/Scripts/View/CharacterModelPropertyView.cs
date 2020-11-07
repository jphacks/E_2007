using VRoidSDK.Examples.Core.View.Parts;
using Component = VRoidSDK.Examples.Core.View.Component;

namespace VRoidSDK.Examples.CharacterModelExample.View
{
    public class CharacterModelPropertyView : Component
    {
        public Message headerTitle;
        public Message modelId;
        public Message specVersion;
        public Message exporterVersion;
        public Message triangleCount;
        public Message meshCount;
        public Message meshPrimitiveCount;
        public Message meshPrimitiveMorphCount;
        public Message textureCount;
        public Message jointCount;
        public Message materialCount;
        public VerticalScrollGroup materialDetails;
        public Button closeButton;
    }
}
