using VRoidSDK.Examples.Core.View;
using UnityEngine;
using UnityEngine.UI;
using Component = VRoidSDK.Examples.Core.View.Component;

namespace VRoidSDK.Examples.Core.View.Parts
{
    public class ToggleBox : Component
    {
        [SerializeField] private UnityEngine.UI.Toggle _toggle;
        public Message Message;

        public bool Checked
        {
            get
            {
                return _toggle.isOn;
            }
            set
            {
                _toggle.isOn = value;
            }
        }
    }
}
