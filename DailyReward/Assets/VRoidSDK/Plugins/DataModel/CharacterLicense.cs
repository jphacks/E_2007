using System;

namespace VRoidSDK
{
    /// <summary>
    /// キャラクターの利用条件
    /// </summary>
    public struct CharacterLicense
    {
        /// <summary>
        /// 改変
        /// </summary>
        /// <remarks>
        /// <para>allow: 許可</para>
        /// <para>disallow: 不可</para>
        /// <para>default: 未設定</para>
        /// </remarks>
        public string modification;

        /// <summary>
        /// 再配布
        /// </summary>
        /// <remarks>
        /// <para>allow: 許可</para>
        /// <para>disallow: 不可</para>
        /// <para>default: 未設定</para>
        /// </remarks>
        public string redistribution;

        /// <summary>
        /// クレジット表記
        /// </summary>
        /// <remarks>
        /// <para>necessary: 必要</para>
        /// <para>unnecessary: 不要</para>
        /// <para>default: 未設定</para>
        /// </remarks>
        public string credit;

        /// <summary>
        /// アバターとしての利用
        /// </summary>
        /// <remarks>
        /// <para>everyone: 全員に許可</para>
        /// <para>author: 作成者のみ許可</para>
        /// <para>default: 未設定</para>
        /// </remarks>
        public string characterization_allowed_user;

        /// <summary>
        /// 性的表現での利用
        /// </summary>
        /// <remarks>
        /// <para>allow: 許可</para>
        /// <para>disallow: 不可</para>
        /// <para>default: 未設定</para>
        /// </remarks>
        public string sexual_expression;

        /// <summary>
        /// 暴力表現での利用
        /// </summary>
        /// <remarks>
        /// <para>allow: 許可</para>
        /// <para>disallow: 不可</para>
        /// <para>default: 未設定</para>
        /// </remarks>
        public string violent_expression;

        /// <summary>
        /// 法人の商用利用
        /// </summary>
        /// <remarks>
        /// <para>allow: 許可</para>
        /// <para>disallow: 不可</para>
        /// <para>default: 未設定</para>
        /// </remarks>
        public string corporate_commercial_use;

        /// <summary>
        /// 個人の商用利用
        /// </summary>
        /// <remarks>
        /// <para>profit: 営利目的の活動に利用を許可</para>
        /// <para>nonprofit: 非営利目的の活動に限り利用を許可</para>
        /// <para>disallow: 商用利用不可</para>
        /// <para>default: 未設定</para>
        /// </remarks>
        public string personal_commercial_use;

        public EnumLicense WhatModification()
        {
            if (modification == "allow")
            {
                return EnumLicense.ok;
            }
            else if (modification == "default")
            {
                return EnumLicense.notset;
            }
            else
            {
                return EnumLicense.ng;
            }
        }

        public EnumLicense WhatRedistribution()
        {
            if (redistribution == "allow")
            {
                return EnumLicense.ok;
            }
            else if (redistribution == "default")
            {
                return EnumLicense.notset;
            }
            else
            {
                return EnumLicense.ng;
            }
        }

        public EnumLicense WhatCanUseAvatar()
        {
            if (characterization_allowed_user == "everyone")
            {
                return EnumLicense.ok;
            }
            else if (characterization_allowed_user == "default")
            {
                return EnumLicense.notset;
            }
            else
            {
                return EnumLicense.ng;
            }
        }

        public EnumLicense WhatCanUseCorporateCommercial()
        {
            if (corporate_commercial_use == "allow")
            {
                return EnumLicense.ok;
            }
            else if (corporate_commercial_use == "default")
            {
                return EnumLicense.notset;
            }
            else
            {
                return EnumLicense.ng;
            }
        }

        public EnumLicense WhatCanUsePersonalCommercial()
        {
            if (personal_commercial_use == "profit")
            {
                return EnumLicense.profit;
            }
            else if (personal_commercial_use == "default")
            {
                return EnumLicense.notset;
            }
            else if (personal_commercial_use == "nonprofit")
            {
                return EnumLicense.nonprofit;
            }
            else
            {
                return EnumLicense.ng;
            }
        }

        public EnumLicense WhatCanUseSexuality()
        {
            if (sexual_expression == "allow")
            {
                return EnumLicense.ok;
            }
            else if (sexual_expression == "default")
            {
                return EnumLicense.notset;
            }
            else
            {
                return EnumLicense.ng;
            }
        }

        public EnumLicense WhatCanUseViolence()
        {
            if (violent_expression == "allow")
            {
                return EnumLicense.ok;
            }
            else if (violent_expression == "default")
            {
                return EnumLicense.notset;
            }
            else
            {
                return EnumLicense.ng;
            }
        }

        public EnumLicense WhatShowCredit()
        {
            if (credit == "necessary")
            {
                return EnumLicense.need;
            }
            else if (credit == "default")
            {
                return EnumLicense.notset;
            }
            else
            {
                return EnumLicense.noneed;
            }
        }
    }
}
