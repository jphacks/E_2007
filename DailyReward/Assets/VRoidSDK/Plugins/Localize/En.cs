using System.Collections.Generic;

namespace VRoidSDK.Localize
{
    /// <summary>
    /// 英語表記のローカライズをするクラス
    /// </summary>
    public class En : ILocalize
    {
        private static readonly Dictionary<string, string> s_localeDictionary = new Dictionary<string, string>()
        {
            { Key.LicenseTypeOk, "YES" },
            { Key.LicenseTypeNg, "NO" },
            { Key.LicenseTypeNeed, "Necessary" },
            { Key.LicenseTypeNoNeed, "Unnecessary" },
            { Key.LicenseTypeProfit, "YES - For-profit use (donations)" },
            { Key.LicenseTypeNonProfit, "YES - Individual non-profit use" },
            { Key.LicenseTypeNotSet, "DEFAULT" },
            { Key.LicenseTextTitle, "Conditions of use for this model" },
            { Key.LicenseTextCanUseAvatar, "Avatar use" },
            { Key.LicenseTextCanUseViolence, "Violence" },
            { Key.LicenseTextCanUseSexuality, "Sexual acts" },
            { Key.LicenseTextCanUseCorporateCommercial, "Commercial use by corporates" },
            { Key.LicenseTextCanUsePersonalCommercial, "Commercial use by individuals" },
            { Key.LicenseTextCanModify, "Alterations" },
            { Key.LicenseTextCanRedistribute, "Redistribution" },
            { Key.LicenseTextShowCredit, "Attribution" },
        };

        /// <summary>
        /// 任意の文字列を受け取り英語表記を出力する
        /// </summary>
        /// <param name="key">ローカライズのキー</param>
        /// <returns>英語表記の文字列</returns>
        /// <remarks>
        /// 存在しないキーが渡されたとき、キーの値をそのまま出力する
        /// </remarks>
        public virtual string Get(string key)
        {
            if (s_localeDictionary.ContainsKey(key))
            {
                return s_localeDictionary[key];
            }

            return key;
        }
    }
}
