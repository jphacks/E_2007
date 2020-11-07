using System.Collections.Generic;
using VRoidSDK.Examples.Core.Model;
using UnityEngine;

namespace VRoidSDK.Examples.ArtworkExample.Model
{
    public class ArtworkDetailModel : ApplicationModel
    {
        public ArtworkDetail ArtworkDetail { get; set; }

        public ArtworkDetailModel()
        {
            ArtworkDetail = null;
        }
    }
}
