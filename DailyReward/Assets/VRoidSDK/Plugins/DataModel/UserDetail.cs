using System;
using System.Collections.Generic;

namespace VRoidSDK
{
    /// <summary>
    /// ユーザの詳細情報
    /// </summary>
    public struct UserDetail
    {
        /// <summary>
        /// 紐づくユーザ情報
        /// </summary>
        public User user;

        /// <summary>
        /// プロフィール情報
        /// </summary>
        public string description;

        /// <summary>
        /// プロフィールを分割した情報
        /// </summary>
        public List<DescriptionFragment> description_fragments;
    }
}
