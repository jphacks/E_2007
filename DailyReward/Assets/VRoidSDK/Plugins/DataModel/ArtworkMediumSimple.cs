using System;
using System.Collections.Generic;

namespace VRoidSDK
{
    /// <summary>
    /// 必要最低限に絞られたメディア情報
    /// </summary>
    public class ArtworkMediumSimple
    {
        /// <summary>
        /// アートワークの種類
        /// </summary>
        public EnumArtworkMediumType type;

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
