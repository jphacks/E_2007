using System.Collections.Generic;
using UnityEngine;

namespace VRoidSDK.Examples.Core.View.Parts
{
    public class Tab : Component
    {
        [SerializeField] private List<ToggleImage> _tabItems;
        [SerializeField] private int _activeIndex = 0;

        public int ActiveIndex
        {
            get
            {
                return _activeIndex;
            }
            set
            {
                if (value > _tabItems.Count) return;
                _activeIndex = value;
                for (int x = 0; x < _tabItems.Count; x++)
                {
                    if (x == value) _tabItems[x].ToggleActive = true;
                    else _tabItems[x].ToggleActive = false;
                }
            }
        }
    }
}
