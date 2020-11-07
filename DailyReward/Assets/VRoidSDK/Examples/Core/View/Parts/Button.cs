using UnityEngine;

namespace VRoidSDK.Examples.Core.View.Parts
{
    public class Button : Component
    {
        [SerializeField] private UnityEngine.UI.Button _button;
        public Message Message;

        public bool Enable
        {
            get
            {
                return _button.interactable;
            }
            set
            {
                _button.interactable = value;
            }
        }
    }
}
