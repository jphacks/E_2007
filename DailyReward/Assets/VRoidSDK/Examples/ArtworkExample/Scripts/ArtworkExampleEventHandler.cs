using UnityEngine;
using VRoidSDK.Examples.Core.Localize;

namespace VRoidSDK.Examples.ArtworkExample
{
    public abstract class ArtworkExampleEventHandler : MonoBehaviour
    {
        public abstract void OnLangChanged(Translator.Locales locale);
    }
}
