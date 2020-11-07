using System;
using System.Collections.Generic;

namespace VRoidSDK
{
    /// <summary>
    /// アートワークのメディア情報
    /// </summary>
    public class ArtworkMedium
    {
        /// <summary>
        /// メディアのID
        /// </summary>
        public string id;

        /// <summary>
        /// アートワークの種類
        /// </summary>
        public EnumArtworkMediumType type;

        /// <summary>
        /// 紐づくキャラクターモデル
        /// </summary>
        public List<ArtworkMediumCharacterModel> character_models;

        /// <summary>
        /// アートワークの画像
        /// </summary>
        /// <remarks>
        /// typeがYoutube動画の場合はnullになる
        /// </remarks>
        public ArtworkImage image;

        /// <summary>
        /// アートワークのYoutube動画
        /// </summary>
        /// <remarks>
        /// typeが画像の場合はnullになる
        /// </remarks>
        public ArtworkYoutube youtube;
    }
}
