using System.Collections.Generic;

namespace VRoidSDK.Localize
{
    /// <summary>
    /// 日本語表記のローカライズをするクラス
    /// </summary>
    public class Ja : En
    {
        private static readonly Dictionary<string, string> s_localeDictionary = new Dictionary<string, string>()
        {
            { Key.LicenseTypeOk, "OK" },
            { Key.LicenseTypeNg, "NG" },
            { Key.LicenseTypeNeed, "必要" },
            { Key.LicenseTypeNoNeed, "不要" },
            { Key.LicenseTypeProfit, "OK - ギフティング" },
            { Key.LicenseTypeNonProfit, "OK - 同人" },
            { Key.LicenseTypeNotSet, "未設定" },
            { Key.LicenseTextTitle, "モデルデータの利用条件" },
            { Key.LicenseTextCanUseAvatar, "アバターでの利用" },
            { Key.LicenseTextCanUseViolence, "暴力表現での利用" },
            { Key.LicenseTextCanUseSexuality, "性的表現での利用" },
            { Key.LicenseTextCanUseCorporateCommercial, "法人の商用利用" },
            { Key.LicenseTextCanUsePersonalCommercial, "個人の商用利用" },
            { Key.LicenseTextCanModify, "改変" },
            { Key.LicenseTextCanRedistribute, "再配布" },
            { Key.LicenseTextShowCredit, "クレジット表記" },
        };

        /// <summary>
        /// 任意の文字列を受け取り日本語表記を出力する
        /// </summary>
        /// <param name="key">ローカライズのキー</param>
        /// <returns>日本語表記の文字列</returns>
        /// <remarks>
        /// ローカライズのキーがない場合、基底クラスにフォールバックする
        /// </remarks>
        public override string Get(string key)
        {
            if (s_localeDictionary.ContainsKey(key))
            {
                return s_localeDictionary[key];
            }

            return base.Get(key);
        }
    }
}
