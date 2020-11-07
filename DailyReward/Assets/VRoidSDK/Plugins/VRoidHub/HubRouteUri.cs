using System;

namespace VRoidSDK
{
    /// <summary>
    /// VRoidHubのURLを生成する
    /// </summary>
    public class HubRouteUri
    {
        public static Uri Application(string applicationId)
        {
            return new Uri(EnvironmentConfig.HttpHostUrl + "/apps/" + applicationId);
        }

        public static Uri Character(Character character)
        {
            return new Uri(EnvironmentConfig.HttpHostUrl + "/characters/" + character.id);
        }

        public static Uri CharacterModel(CharacterModel characterModel)
        {
            var characterId = characterModel.character.id;
            return new Uri(EnvironmentConfig.HttpHostUrl + "/characters/" + characterId + "/models/" + characterModel.id);
        }

        public static Uri CharacterModelEdit(CharacterModel characterModel)
        {
            var characterId = characterModel.character.id;
            return new Uri(EnvironmentConfig.HttpHostUrl + "/characters/" + characterId + "/models/" + characterModel.id + "/edit");
        }

        public static Uri Hearts()
        {
            return new Uri(EnvironmentConfig.HttpHostUrl + "/hearts");
        }
        public static Uri Home()
        {
            return new Uri(EnvironmentConfig.HttpHostUrl);
        }

        public static Uri Models()
        {
            return new Uri(EnvironmentConfig.HttpHostUrl + "/models");
        }

        public static Uri Setting()
        {
            return new Uri(EnvironmentConfig.HttpHostUrl + "/settings");
        }

        public static Uri Tag(string tag)
        {
            return new Uri(EnvironmentConfig.HttpHostUrl + "/tags/" + tag);
        }

        public static Uri User(User user)
        {
            return new Uri(EnvironmentConfig.HttpHostUrl + "/users/" + user.pixiv_user_id);
        }

        public static Uri Artwork(Artwork artwork)
        {
            return new Uri(EnvironmentConfig.HttpHostUrl + "/artworks/" + artwork.id);
        }
    }
}
