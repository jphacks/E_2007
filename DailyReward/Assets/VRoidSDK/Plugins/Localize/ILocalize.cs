using System.Collections.Generic;

namespace VRoidSDK.Localize
{
    /// <summary>
    /// ローカライズのクラスを作るためのインターフェース
    /// </summary>
    public interface ILocalize
    {
        /// <summary>
        /// 任意の文字列を受け取りローカライズ後の言語を出力する
        /// </summary>
        /// <param name="key">ローカライズのキー</param>
        /// <returns>ローカライズした文字列</returns>
        string Get(string key);
    }
}
