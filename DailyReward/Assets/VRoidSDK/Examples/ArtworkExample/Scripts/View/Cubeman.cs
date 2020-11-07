using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRoidSDK.Examples.ArtworkExample.View
{
    public class Cubeman : MonoBehaviour
    {
        private void Start()
        {
            var asset = Resources.Load("Cubeman.vrm") as TextAsset;
            var vrm = VRM.VRMImporter.LoadFromBytes(asset.bytes);
            vrm.transform.parent = this.transform;
        }
    }
}
