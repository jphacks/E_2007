using System;

namespace VRoidSDK
{
    /// <summary>
    /// VRoidHubでピックアップされているキャラクターモデル
    /// </summary>
    public class StaffPicksCharacterModel
    {
        /// <summary>
        /// キャラクターモデル
        /// </summary>
        public CharacterModel character_model;

        /// <summary>
        /// 作成日時
        /// </summary>
        public string created_at;

        /// <summary>
        /// ピックアップされた日時を取得する
        /// </summary>
        /// <returns>ピックアップ日時</returns>
        public DateTime? PickupAt()
        {
            if (string.IsNullOrEmpty(created_at))
            {
                return null;
            }
            return DateTime.Parse(created_at);
        }
    }
}
