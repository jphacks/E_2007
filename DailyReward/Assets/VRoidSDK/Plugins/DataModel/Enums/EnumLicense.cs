
namespace VRoidSDK
{
    /// <summary>
    /// ライセンス項目の設定値
    /// </summary>
    public enum EnumLicense
    {
        /// <summary>
        /// 「利用が許可されている」条件
        /// </summary>
        ok,

        /// <summary>
        /// 「利用が許可されていない」条件
        /// </summary>
        ng,

        /// <summary>
        /// 「ライセンス表示が必要」の条件
        /// </summary>
        need,

        /// <summary>
        /// 「ライセンス表示が不要」の条件
        /// </summary>
        noneed,

        /// <summary>
        /// 「営利目的で個人の商用利用可」の条件
        /// </summary>
        profit,

        /// <summary>
        /// 「非営利目的に限り個人の商用利用可」の条件
        /// </summary>
        nonprofit,

        /// <summary>
        /// 「未設定」にセットされている条件
        /// </summary>
        /// <remarks>
        /// VRoidHubにアップロードし、一度も非公開にしていない自分のモデルのライセンスはこの値になる
        /// </remarks>
        notset,
    }
}
