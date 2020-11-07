using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace VRoidSDK
{
    /// <summary>
    /// GLTFのmaterial
    /// </summary>
    /// <remarks>
    /// APIの仕様上、完全なmaterialではないことに注意
    /// </remarks>
    public class GltfMaterial
    {
        /// <summary>
        /// マテリアル名
        /// </summary>
        public string name;

        /// <summary>
        /// alphaMode
        /// </summary>
        public string alpha_mode;

        /// <summary>
        /// doubleSided
        /// </summary>
        public bool double_sided;

        /// <summary>
        /// 拡張設定
        /// </summary>
        /// <remarks>
        /// VRM 0.0では、KHR_materials_unlitのみ。
        /// </remarks>
        public Dictionary<string, JObject> extensions;
    }
}
