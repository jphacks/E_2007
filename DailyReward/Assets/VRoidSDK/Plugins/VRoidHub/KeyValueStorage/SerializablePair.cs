using System;
using UnityEngine;

namespace VRoidSDK
{
    [Serializable]
    abstract public class SerializablePair<T> where T : class
    {
        [SerializeField]
        private string _key;

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        abstract public T Value { get; set; }
    }
}
