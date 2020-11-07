using System.Collections.Generic;

namespace VRoidSDK
{
    /// <summary>
    /// モデルのプロパティ情報
    /// </summary>
    public class CharacterModelProperty
    {
        /// <summary>
        /// キャラクターモデルのID
        /// </summary>
        public string id;

        /// <summary>
        /// キャラクターモデルバージョンのID
        /// </summary>
        public string character_model_version_id;

        /// <summary>
        /// VRMのspecVersion
        /// </summary>
        /// <remarks>
        /// UniVRM v0.50で追加された項目
        /// 0.50未満のUniVRMで作られたVRMの場合nullになる
        /// </remarks>
        public string spec_version;

        /// <summary>
        /// VRMのexporterVersion
        /// </summary>
        public string exporter_version;

        /// <summary>
        /// 三角ポリゴンの数
        /// </summary>
        public int triangle_count;

        /// <summary>
        /// メッシュ数
        /// </summary>
        public int mesh_count;

        /// <summary>
        /// サブメッシュ数
        /// </summary>
        public int mesh_primitive_count;

        /// <summary>
        /// モーフ数
        /// </summary>
        public int mesh_primitive_morph_count;

        /// <summary>
        /// マテリアル数
        /// </summary>
        public int material_count;

        /// <summary>
        /// テクスチャ数
        /// </summary>
        public int texture_count;

        /// <summary>
        /// ジョイント数
        /// </summary>
        public int joint_count;

        /// <summary>
        /// マテリアル詳細
        /// </summary>
        public CharacterModelVersionMaterial character_model_version_material;
    }
}
