using System.Collections.Generic;

namespace VRoidSDK
{
    /// <summary>
    /// マテリアル詳細
    /// </summary>
    public class CharacterModelVersionMaterial
    {
        /// <summary>
        /// GLTFのmaterial schema
        /// </summary>
        public List<GltfMaterial> materials;

        /// <summary>
        /// VRM拡張部のmaterial schema
        /// </summary>
        /// <remarks>
        /// VRM1.0のドラフト仕様より、VRM拡張部のmaterialPropertiesは削除される
        /// そのため、この値はnullになりうるのでnullチェックを必須にし、
        /// 利用する場合は、VRM1.0未満の場合のみを対象にすること
        /// </remarks>
        public List<ExtensionsVrmMaterialProperty> extensions_vrm_materialproperties;
    }
}
