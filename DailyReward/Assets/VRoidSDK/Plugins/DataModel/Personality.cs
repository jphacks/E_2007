using System;

namespace VRoidSDK
{
    /// <summary>
    /// 性格情報
    /// </summary>
    public class Personality
    {
        /// <summary>
        ///  性格の識別子
        /// </summary>
        public string name;

        /// <summary>
        ///  性格を表示するときの表記(実行しているVRoidHubのユーザーの言語設定に応じて言語が変わります)
        /// </summary>
        public string label;

        /// <summary>
        ///  性格を表示するときの表記(英語)
        /// </summary>
        public string label_en;

        public Personality()
        {
        }

        /// <summary>
        /// nameをPersonalityNameへ変換します。もしPersonalityNameへ合致するものがなかった場合は、PersonalityName.Standard を返します。
        /// </summary>
        /// <returns>PersonalityName</returns>
        public PersonalityName PersonalityName
        {
            get
            {
                foreach (PersonalityName type in Enum.GetValues(typeof(PersonalityName)))
                {
                    var name = Enum.GetName(typeof(PersonalityName), type);
                    if (name.ToLower() == this.name)
                    {
                        return type;
                    }
                }
                return PersonalityName.Standard;
            }
        }
    }

    /// <summary>
    ///  性格名の一覧
    /// </summary>
    public enum PersonalityName
    {
        /// <summary>
        /// 標準
        /// </summary>
        Standard = 0,
        /// <summary>
        /// 無邪気
        /// </summary>
        Innocent = 1,
        /// <summary>
        /// クール
        /// </summary>
        Cool = 2,
        /// <summary>
        /// おしとやか
        /// </summary>
        LadyLike = 3,
        /// <summary>
        /// シャイ
        /// </summary>
        Shy = 4,
        /// <summary>
        /// 元気
        /// </summary>
        Energetic = 5,
        /// <summary>
        /// 華麗
        /// </summary>
        Flamboyant = 6,
        /// <summary>
        /// 紳士
        /// </summary>
        Gentleman = 7,
        /// <summary>
        /// パワフル
        /// </summary>
        Powerful = 8,
    }
}
