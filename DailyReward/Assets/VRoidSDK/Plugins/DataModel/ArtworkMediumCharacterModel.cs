using System;
using System.Collections.Generic;

namespace VRoidSDK
{
    /// <summary>
    /// ArtworkMediumで利用するキャラクターモデルデータ
    /// </summary>
    public class ArtworkMediumCharacterModel
    {
        /// <summary>
        /// キャラクターモデルID
        /// </summary>
        public string id;

        /// <summary>
        /// キャラクターID
        /// </summary>
        public string character_id;

        /// <summary>
        /// キャラクターの名前
        /// </summary>
        /// <remarks>
        /// 設定をしていない場合はnullになる
        /// </remarks>
        public string character_name;

        /// <summary>
        /// 非公開かどうか
        /// </summary>
        public bool is_private;

        /// <summary>
        /// バストアップ画像
        /// </summary>
        public PortraitImage portrait_image;
    }
}
