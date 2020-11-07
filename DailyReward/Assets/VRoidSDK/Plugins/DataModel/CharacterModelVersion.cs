using System;

namespace VRoidSDK
{
    /// <summary>
    /// キャラクターのバージョン
    /// </summary>
    public struct CharacterModelVersion
    {
        /// <summary>
        /// バージョンID
        /// </summary>
        public string id;

        /// <summary>
        /// 作成日時
        /// </summary>
        public string created_at;

        /// <summary>
        /// VRMのspecVersion (非推奨)
        /// </summary>
        /// <remarks>
        /// UniVRM v0.50で追加された項目
        /// 0.50未満のUniVRMで作られたモデルの場合nullになる
        /// </remarks>
        [Obsolete("spec_version is Deprecated. Please use CharacterModelProperty#spec_version instead.", false)]
        public string spec_version;

        /// <summary>
        /// 三角ポリゴンの数 (非推奨)
        /// </summary>
        [Obsolete("triangle_count is Deprecated. Please use CharacterModelProperty#triangle_count instead.", false)]
        public int triangle_count;

        /// <summary>
        /// メッシュ数 (非推奨)
        /// </summary>
        [Obsolete("mesh_count is Deprecated. Please use CharacterModelProperty#mesh_count instead.", false)]
        public int mesh_count;

        /// <summary>
        /// サブメッシュ数 (非推奨)
        /// </summary>
        [Obsolete("mesh_primitive_count is Deprecated. Please use CharacterModelProperty#mesh_primitive_count instead.", false)]
        public int mesh_primitive_count;

        /// <summary>
        /// モーフ数 (非推奨)
        /// </summary>
        [Obsolete("mesh_primitive_morph_count is Deprecated. Please use CharacterModelProperty#mesh_primitive_morph_count instead.", false)]
        public int mesh_primitive_morph_count;

        /// <summary>
        /// ジョイント数 (非推奨)
        /// </summary>
        [Obsolete("joint_count is Deprecated. Please use CharacterModelProperty#joint_count instead.", false)]
        public int joint_count;

        /// <summary>
        /// マテリアル数 (非推奨)
        /// </summary>
        [Obsolete("material_count is Deprecated. Please use CharacterModelProperty#material_count instead.", false)]
        public int material_count;

        /// <summary>
        /// テクスチャ数 (非推奨)
        /// </summary>
        [Obsolete("texture_count is Deprecated. Please use CharacterModelProperty#texture_count instead.", false)]
        public int texture_count;

        /// <summary>
        /// VRMファイルの容量
        /// </summary>
        public int? original_file_size;

        /// <summary>
        /// VRMファイルの圧縮容量(通信上でのサイズ)
        /// </summary>
        public int? original_file_compressed_file_size;

        /// <summary>
        /// 作成日時を取得する
        /// </summary>
        /// <returns>作成日時</returns>
        public DateTime? CreatedAt()
        {
            if (string.IsNullOrEmpty(created_at))
            {
                return null;
            }
            return DateTime.Parse(created_at);
        }
    }
}
