using System;
using System.Collections.Generic;

namespace VRoidSDK
{
    /// <summary>
    /// キャラクターの詳細な情報
    /// </summary>
    public struct CharacterDetail
    {
        /// <summary>
        /// 紐づいているキャラクター
        /// </summary>
        public Character character;

        /// <summary>
        /// キャラクターのプロフィール
        /// </summary>
        /// <remarks>
        /// プロフィールを記載していない場合はnullになる
        /// </remarks>
        public string description;

        /// <summary>
        /// プロフィールを分割した情報
        /// </summary>
        /// <remarks>
        /// プロフィール中に、URLとplainテキストが混じっている場合、分割されて格納される
        /// </remarks>
        public List<DescriptionFragment> description_fragments;

        /// <summary>
        /// 登録したWebサイト
        /// </summary>
        public List<WebSite> websites;
    }
}
