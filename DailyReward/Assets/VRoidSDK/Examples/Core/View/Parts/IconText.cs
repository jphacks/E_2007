using UnityEngine;
using UnityEngine.UI;

namespace VRoidSDK.Examples.Core.View.Parts
{
    public class IconText : Component
    {
        [SerializeField] private Text _text;
        [SerializeField] private LoadImage _icon;

        public void Set(string text, WebImage icon)
        {
            _text.text = text;
            _icon.Load(icon);
        }
    }
}
