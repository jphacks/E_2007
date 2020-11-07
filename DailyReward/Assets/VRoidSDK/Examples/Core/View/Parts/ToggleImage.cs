using VRoidSDK.Examples.Core.View;
using UnityEngine;
using UnityEngine.UI;
using Component = VRoidSDK.Examples.Core.View.Component;

namespace VRoidSDK.Examples.Core.View.Parts
{
    public class ToggleImage : Component
    {
        [SerializeField] private Image _activeImage;
        [SerializeField] private Image _nonActiveImage;

        public bool ToggleActive
        {
            set
            {
                _activeImage.gameObject.SetActive(value);
                _nonActiveImage.gameObject.SetActive(!value);
            }
        }
    }
}
