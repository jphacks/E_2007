using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRoidSDK.Examples.Core.View.Parts
{
    public class VerticalScrollGroup : Component
    {
        [SerializeField] private GameObject _instancePrefab;

        public void Insert<T, U>(List<T> data, Action<U> onSelect)
            where U : VerticalScrollItem<T>
        {
            DeleteAllChildren();
            foreach (var d in data)
            {
                var x = AddChild<U>(_instancePrefab);
                x.Init(d);
                if (onSelect != null)
                {
                    x.OnSelect = (i) => onSelect((U)i);
                }
            }
        }
    }
}
