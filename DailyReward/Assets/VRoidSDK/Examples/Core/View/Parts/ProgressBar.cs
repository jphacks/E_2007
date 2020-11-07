using UnityEngine;
using UnityEngine.UI;

namespace VRoidSDK.Examples.Core.View.Parts
{
    public class ProgressBar : Component
    {
        [SerializeField] private Slider _slider;
        public float Value
        {
            get
            {
                return _slider.value;
            }
            set
            {
                _slider.value = value;
            }
        }
    }
}
