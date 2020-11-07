using System;
using System.Collections.Generic;

namespace VRoidSDK
{
    /// <summary>
    /// キャラクターモデル詳細
    /// </summary>
    public struct CharacterModelDetail
    {
        /// <summary>
        /// 紐づくキャラクターモデル
        /// </summary>
        public CharacterModel character_model;

        /// <summary>
        /// モデルの説明
        /// </summary>
        public string description;

        /// <summary>
        /// モデルデータの説明文を分割したリスト
        /// </summary>
        /// <remarks>
        /// 説明文はURL, plainテキスト, ハッシュタグで分割される
        /// </remarks>
        public List<DescriptionFragment> description_fragments;

        /// <summary>
        /// モデルに紐づくキャラクターの詳細情報
        /// </summary>
        public CharacterDetail character_detail;


        /// <summary>
        ///  モデルに紐づく性格情報
        /// </summary>
        public Personality personality;
    }
}
