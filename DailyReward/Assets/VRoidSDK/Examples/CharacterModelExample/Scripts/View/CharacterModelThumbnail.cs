using UnityEngine;
using VRoidSDK;
using VRoidSDK.Examples.Core.View.Parts;

namespace VRoidSDK.Examples.CharacterModelExample.View
{
    public class CharacterModelThumbnail : VerticalScrollItem<CharacterModel>
    {
        [SerializeField] private LoadImage _image;

        public CharacterModel CharacterModel { get; private set; }

        public override void Init(CharacterModel baseData)
        {
            CharacterModel = baseData;
            _image.Load(baseData.portrait_image.sq150);
        }
    }
}
