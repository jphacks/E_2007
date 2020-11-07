using UnityEngine;
using VRoidSDK.Examples.Core.Model;

namespace VRoidSDK.Examples.ArtworkExample.Model
{
    public class ArtworkUploadModel : ApplicationModel
    {
        public Texture2D ScreenShot { get; set; }
        public EnumAgeLimit AgeLimit { get; set; }
        public bool UploadProgressActive { get; set; }
        public bool SimulateMode { get; set; }
        public float Progress { get; set; }
        public string Caption { get; set; }

        public ArtworkUploadModel()
        {
            AgeLimit = EnumAgeLimit.normal;
            UploadProgressActive = false;
            Caption = "";
            Progress = 0.0f;
            SimulateMode = true;
        }
    }
}
