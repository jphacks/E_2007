using System;
using System.Collections.Generic;

namespace VRoidSDK
{
    /// <summary>
    /// アートワーク詳細
    /// </summary>
    public class ArtworkDetail
    {
        /// <summary>
        /// アートワークの基本情報
        /// </summary>
        public Artwork artwork;

        /// <summary>
        /// キャプション
        /// </summary>
        public string caption;

        /// <summary>
        /// 対応するArtworkMedium
        /// </summary>
        public List<ArtworkMedium> media;

        /// <summary>
        /// キャプションを分割した情報
        /// </summary>
        public List<DescriptionFragment> caption_fragments;

        /// <summary>
        /// 参加しているコンテスト
        /// </summary>
        public Contest contest;

        /// <summary>
        /// 撮影したアプリケーション
        /// </summary>
        public CaptureApplication capture_application;

        /// <summary>
        /// 閲覧数
        /// </summary>
        public int view_count;

        /// <summary>
        /// ハート数
        /// </summary>
        public int heart_count;
    }
}
