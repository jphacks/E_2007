using System;
using System.Collections.Generic;
using VRoidSDK.Networking;

namespace VRoidSDK
{
    /// <summary>
    /// VRoid HubへAPIリクエストを送信する
    /// </summary>
    /// <remarks>
    /// APIとして使えるものは、SDKConfigurationとアプリケーション管理画面で作成したアプリケーションのスコープ設定により制限される
    ///
    /// どのスコープでAPIが実行できるかは、各メソッドのRemarksを参照してください
    /// </remarks>
    public class HubApi
    {
        /// <summary>
        /// VRoid Hubにログインしているユーザ情報を取得する
        /// </summary>
        /// <param name="onSuccess">取得に成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetAccount(Action<Account> onSuccess, Action<ApiErrorFormat> onError)
        {
            var request = new GenericDataRequest<Account>("/api/account");
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// ユーザが作成したキャラクターモデル一覧を取得する (関連のリンク情報付き)
        /// </summary>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="maxId">キャラクターに紐づくモデルの取得上限ID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetAccountCharacterModels(int count, string maxId, Action<List<CharacterModel>, ApiLinksFormat> onSuccess, Action<ApiErrorFormat> onError)
        {
            var requestParams = new ApiRequestParam();
            if (!string.IsNullOrEmpty(maxId))
            {
                requestParams.AddParam("max_id", maxId);
            }
            requestParams.AddParam("count", count.ToString());

            var request = new GenericDataRequest<List<CharacterModel>>("/api/account/character_models")
            {
                Params = requestParams
            };
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// ユーザが作成したキャラクターモデル一覧を取得する
        /// </summary>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="maxId">キャラクターに紐づくモデルの取得上限ID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetAccountCharacterModels(int count, string maxId, Action<List<CharacterModel>> onSuccess, Action<ApiErrorFormat> onError)
        {
            GetAccountCharacterModels(count, maxId, OmitApiLinksFormat<List<CharacterModel>>(onSuccess), onError);
        }

        /// <summary>
        /// ユーザが作成したキャラクターモデル一覧を取得する (関連のリンク情報付き)
        /// </summary>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetAccountCharacterModels(int count,
            Action<List<CharacterModel>, ApiLinksFormat> onSuccess, Action<ApiErrorFormat> onError)
        {
            GetAccountCharacterModels(count, null, onSuccess, onError);
        }

        /// <summary>
        /// ユーザが作成したキャラクターモデル一覧を取得する
        /// </summary>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetAccountCharacterModels(int count,
            Action<List<CharacterModel>> onSuccess, Action<ApiErrorFormat> onError)
        {
            GetAccountCharacterModels(count, null, onSuccess, onError);
        }

        /// <summary>
        /// ユーザが作成したキャラクター一覧を取得する (関連のリンク情報付き)
        /// </summary>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="maxId">ページング処理のための上限となるモデルID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetAccountCharacters(int count, string maxId, Action<List<Character>, ApiLinksFormat> onSuccess, Action<ApiErrorFormat> onError)
        {
            var requestParams = new ApiRequestParam();
            if (!string.IsNullOrEmpty(maxId))
            {
                requestParams.AddParam("max_id", maxId);
            }
            requestParams.AddParam("count", count.ToString());

            var request = new GenericDataRequest<List<Character>>("/api/account/characters")
            {
                Params = requestParams
            };
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// ユーザが作成したキャラクター一覧を取得する
        /// </summary>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="maxId">ページング処理のための上限となるモデルID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetAccountCharacters(int count, string maxId, Action<List<Character>> onSuccess, Action<ApiErrorFormat> onError)
        {
            GetAccountCharacters(count, maxId, OmitApiLinksFormat<List<Character>>(onSuccess), onError);
        }

        /// <summary>
        /// ユーザが作成したキャラクター一覧を取得する (関連のリンク情報付き)
        /// </summary>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetAccountCharacters(int count, Action<List<Character>, ApiLinksFormat> onSuccess, Action<ApiErrorFormat> onError)
        {
            GetAccountCharacters(count, null, onSuccess, onError);
        }

        /// <summary>
        /// ユーザが作成したキャラクター一覧を取得する
        /// </summary>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetAccountCharacters(int count, Action<List<Character>> onSuccess, Action<ApiErrorFormat> onError)
        {
            GetAccountCharacters(count, null, onSuccess, onError);
        }

        /// <summary>
        /// キャラクターモデルの詳細情報を取得する
        /// </summary>
        /// <param name="characterModelId">詳細情報を取得したいキャラクターモデルID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetCharacterModel(string characterModelId, Action<CharacterModelDetail> onSuccess, Action<ApiErrorFormat> onError)
        {
            var request = new GenericDataRequest<CharacterModelDetail>("/api/character_models/" + characterModelId);
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// 複数のキャラクターのモデル情報をID指定でまとめて取得する
        /// </summary>
        /// <param name="characterModelIds">キャラクターモデルのID一覧. 最大100件まで対応可能</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void PostCharacterModelBatch(string[] characterModelIds, Action<List<CharacterModel>> onSuccess,
            Action<ApiErrorFormat> onError)
        {
            var requestParams = new ApiRequestParam();
            for (int i = 0; i < characterModelIds.Length; ++i)
            {
                requestParams.AddParam("ids[]", characterModelIds[i]);
            }

            var request = new GenericDataRequest<List<CharacterModel>>("/api/character_models/batch")
            {
                Methods = HTTPMethods.Post,
                Params = requestParams
            };
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// キャラクターの詳細情報を取得する
        /// </summary>
        /// <param name="characterId">取得したいキャラクターのID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetCharacter(string characterId, Action<CharacterDetail> onSuccess, Action<ApiErrorFormat> onError)
        {
            var request = new GenericDataRequest<CharacterDetail>("/api/characters/" + characterId);
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// キャラクターに紐づくキャラクターモデル一覧を取得する (関連のリンク情報付き)
        /// </summary>
        /// <param name="characterId">キャラクターのID</param>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="maxId">ページング処理のための上限となるモデルID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetCharactersModels(string characterId, int count, string maxId, Action<List<CharacterModel>, ApiLinksFormat> onSuccess, Action<ApiErrorFormat> onError)
        {
            var requestParams = new ApiRequestParam();
            if (!string.IsNullOrEmpty(maxId))
            {
                requestParams.AddParam("max_id", maxId);
            }
            requestParams.AddParam("count", count.ToString());

            var request = new GenericDataRequest<List<CharacterModel>>("/api/characters/" + characterId + "/models")
            {
                Params = requestParams
            };
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// キャラクターに紐づくキャラクターモデル一覧を取得する
        /// </summary>
        /// <param name="characterId">キャラクターのID</param>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="maxId">ページング処理のための上限となるモデルID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetCharactersModels(string characterId, int count, string maxId,
            Action<List<CharacterModel>> onSuccess, Action<ApiErrorFormat> onError)
        {
            GetCharactersModels(characterId, count, maxId, OmitApiLinksFormat<List<CharacterModel>>(onSuccess), onError);
        }

        /// <summary>
        /// キャラクターに紐づくキャラクターモデル一覧を取得する
        /// </summary>
        /// <param name="characterId">キャラクターのID</param>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetCharactersModels(string characterId, int count,
            Action<List<CharacterModel>, ApiLinksFormat> onSuccess, Action<ApiErrorFormat> onError)
        {
            GetCharactersModels(characterId, count, null, onSuccess, onError);
        }

        /// <summary>
        /// キャラクターに紐づくキャラクターモデル一覧を取得する
        /// </summary>
        /// <param name="characterId">キャラクターのID</param>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetCharactersModels(string characterId, int count,
            Action<List<CharacterModel>> onSuccess, Action<ApiErrorFormat> onError)
        {
            GetCharactersModels(characterId, count, null, onSuccess, onError);
        }

        /// <summary>
        /// VRoidHubのピックアップモデル一覧を取得する (関連のリンク情報付き)
        /// </summary>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetStaffPicks(int count, Action<List<StaffPicksCharacterModel>, ApiLinksFormat> onSuccess,
            Action<ApiErrorFormat> onError)
        {
            var requestParams = new ApiRequestParam();
            requestParams.AddParam("count", count.ToString());
            var request = new GenericDataRequest<List<StaffPicksCharacterModel>>("/api/staff_picks")
            {
                Params = requestParams
            };
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// 複数のキャラクターモデルのプロパティ情報を一括取得する
        /// </summary>
        /// <param name="characterModelIds">取得したいキャラクターモデルのIDリスト</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        public static void PostCharacterModelsPropertiesBatch(List<string> characterModelIds,
            Action<List<CharacterModelProperty>> onSuccess, Action<ApiErrorFormat> onError)
        {
            var requestParams = new ApiRequestParam();
            foreach (var characterModelId in characterModelIds)
            {
                requestParams.AddParam("ids[]", characterModelId);
            }

            var request = new GenericDataRequest<List<CharacterModelProperty>>("/api/character_models/properties/batch")
            {
                Methods = HTTPMethods.Post,
                Params = requestParams
            };
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// キャラクターモデルのプロパティ情報を取得する
        /// </summary>
        /// <param name="characterModelId">プロパティ情報を取得するキャラクターモデルID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        public static void GetCharacterModelsProperty(string characterModelId, Action<CharacterModelProperty> onSuccess, Action<ApiErrorFormat> onError)
        {
            var request = new GenericDataRequest<CharacterModelProperty>("/api/character_models/" + characterModelId + "/property");
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// ハートしたモデル一覧を取得する (関連のリンク情報付き)
        /// </summary>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetHearts(int count, Action<List<CharacterModel>, ApiLinksFormat> onSuccess,
            Action<ApiErrorFormat> onError)
        {
            GetHearts(count, null, onSuccess, onError);
        }

        /// <summary>
        /// ハートしたモデル一覧を取得する (関連のリンク情報付き)
        /// </summary>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="maxId">ページング処理のための上限となるモデルID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetHearts(int count, string maxId, Action<List<CharacterModel>, ApiLinksFormat> onSuccess, Action<ApiErrorFormat> onError)
        {
            var requestParams = new ApiRequestParam();
            if (!string.IsNullOrEmpty(maxId))
            {
                requestParams.AddParam("max_id", maxId);
            }
            requestParams.AddParam("count", count.ToString());
            var request = new GenericDataRequest<List<CharacterModel>>("/api/hearts")
            {
                Params = requestParams
            };
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// ハートしたモデル一覧を取得する
        /// </summary>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="maxId">ページング処理のための上限となるモデルID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetHearts(int count, string maxId, Action<List<CharacterModel>> onSuccess,
            Action<ApiErrorFormat> onError)
        {
            GetHearts(count, maxId, OmitApiLinksFormat<List<CharacterModel>>(onSuccess), onError);
        }

        /// <summary>
        /// ハートしたモデル一覧を取得する
        /// </summary>
        /// <param name="count">取得するキャラクターモデル数 (MAX 100)</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetHearts(int count, Action<List<CharacterModel>> onSuccess,
            Action<ApiErrorFormat> onError)
        {
            GetHearts(count, null, onSuccess, onError);
        }

        /// <summary>
        /// モデルにハートをつける
        /// </summary>
        /// <param name="characterModelId">ハートをつけるキャラクターモデルID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: heart
        /// </remarks>
        public static void PostHeart(string characterModelId, Action<EmptySerializer> onSuccess, Action<ApiErrorFormat> onError)
        {
            var requestParams = new ApiRequestParam();
            requestParams.AddParam("character_model_id", characterModelId);
            var request = new GenericDataRequest<EmptySerializer>("/api/hearts")
            {
                Methods = HTTPMethods.Post,
                Params = requestParams
            };
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// キャラクターモデルについているハートを取り消す
        /// </summary>
        /// <param name="characterModelId">ハートを消したいキャラクターモデルID</param>
        /// <param name="onSuccess">成功したときのコールバック</param>
        /// <param name="onError">失敗したときのコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: heart
        /// </remarks>
        public static void DeleteHeart(string characterModelId, Action<EmptySerializer> onSuccess, Action<ApiErrorFormat> onError)
        {
            var requestParams = new ApiRequestParam();
            var request = new GenericDataRequest<EmptySerializer>("/api/hearts/" + characterModelId)
            {
                Methods = HTTPMethods.Delete,
                Params = requestParams
            };
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// ダウンロードライセンス情報を取得
        /// </summary>
        /// <param name="licenseId">取得するライセンスID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetDownloadLicense(string licenseId, Action<DownloadLicense> onSuccess, Action<ApiErrorFormat> onError)
        {
            var requestParams = new ApiRequestParam();
            var request = new GenericDataRequest<DownloadLicense>("/api/download_licenses/" + licenseId)
            {
                Params = requestParams
            };
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// ダウンロードライセンスを発行する
        /// </summary>
        /// <param name="characterModelId">キャラクターモデルID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void PostDownloadLicense(string characterModelId, Action<DownloadLicense> onSuccess, Action<ApiErrorFormat> onError)
        {
            var requestParams = new ApiRequestParam();
            requestParams.AddParam("character_model_id", characterModelId);

            var request = new GenericDataRequest<DownloadLicense>("/api/download_licenses")
            {
                Methods = HTTPMethods.Post,
                Params = requestParams
            };
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// ダウンロードライセンスを無効化する
        /// </summary>
        /// <param name="licenseId">無効化するライセンスID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void DeleteDownloadLicense(string licenseId, Action<EmptySerializer> onSuccess, Action<ApiErrorFormat> onError)
        {
            var requestParams = new ApiRequestParam();
            var request = new GenericDataRequest<EmptySerializer>("/api/download_licenses/" + licenseId)
            {
                Methods = HTTPMethods.Delete,
                Params = requestParams
            };
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// ダウンロードライセンスに紐づくモデルのバージョンを取得(タイムアウトは300秒)
        /// </summary>
        /// <param name="licenseId">ライセンスID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onProgress">APIリクエスト中のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetDownloadLicenseDownload(string licenseId, Action<byte[]> onSuccess, Action<float> onProgress, Action<ApiErrorFormat> onError)
        {
            GetDownloadLicenseDownload(licenseId, 300, onSuccess, onProgress, onError);
        }

        /// <summary>
        /// ダウンロードライセンスに紐づくモデルのバージョンを取得
        /// </summary>
        /// <param name="licenseId">ライセンスID</param>
        /// <param name="timeout">タイムアウト(秒)</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onProgress">APIリクエスト中のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetDownloadLicenseDownload(string licenseId, int timeout, Action<byte[]> onSuccess, Action<float> onProgress, Action<ApiErrorFormat> onError)
        {
            var request = new ByteRequest("/api/download_licenses/" + licenseId + "/download")
            {
                Headers = new Dictionary<string, string>() { { "Accept-Encoding", "gzip" } },
                Timeout = timeout,
                OnDownloadProgress = onProgress
            };
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// ユーザのアートワーク一覧を取得する
        /// </summary>
        /// <param name="user">取得対象のユーザ</param>
        /// <param name="count">取得するアートワークの数</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetUsersArtworks(User user, int count,
            Action<List<Artwork>, ApiLinksFormat> onSuccess, Action<ApiErrorFormat> onError)
        {
            GetUsersArtworks(user, count, null, onSuccess, onError);
        }

        /// <summary>
        /// ユーザのアートワーク一覧を取得する
        /// </summary>
        /// <param name="user">取得対象のユーザ</param>
        /// <param name="count">取得するアートワークの数</param>
        /// <param name="maxId">ページング処理のための上限となるアートワークID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetUsersArtworks(User user, int count, string maxId,
            Action<List<Artwork>, ApiLinksFormat> onSuccess, Action<ApiErrorFormat> onError)
        {
            var requestParams = new ApiRequestParam();
            if (!string.IsNullOrEmpty(maxId))
            {
                requestParams.AddParam("maxId", maxId);
            }
            requestParams.AddParam("count", count.ToString());
            var request = new GenericDataRequest<List<Artwork>>("/api/users/" + user.id + "/artworks")
            {
                Params = requestParams
            };
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// アートワークの詳細を取得する
        /// </summary>
        /// <param name="artworkId">取得するアートワークのID</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">失敗した時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void GetArtwork(string artworkId, Action<ArtworkDetail> onSuccess, Action<ApiErrorFormat> onError)
        {
            var request = new GenericDataRequest<ArtworkDetail>("/api/artworks/" + artworkId);
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// 新しいアートワーク画像をアップロードする
        /// </summary>
        /// <param name="requestParams">送信するパラメータ</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onProgress">アップロード中に呼ばれるコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void PostArtworkMediaImage(PostArtworkMediaImagesParams requestParams, Action<ArtworkMedium> onSuccess, Action<float> onProgress, Action<ApiErrorFormat> onError)
        {
            var request = new GenericDataRequest<ArtworkMedium>("/api/artwork_media/images")
            {
                Methods = HTTPMethods.Post,
                Params = requestParams,
                OnUploadProgress = onProgress
            };
            request.SendRequest(onSuccess, onError);
        }

        /// <summary>
        /// アップロードしたメディアから新規アートワークを作成する
        /// </summary>
        /// <param name="requestParams">送信するパラメータ</param>
        /// <param name="onSuccess">成功した時のコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        /// <remarks>
        /// 使用可能スコープ: default
        /// </remarks>
        public static void PostArtwork(PostArtworksParams requestParams, Action<ArtworkDetail> onSuccess, Action<ApiErrorFormat> onError)
        {
            var request = new GenericDataRequest<ArtworkDetail>("/api/artworks")
            {
                Methods = HTTPMethods.Post,
                Params = requestParams
            };
            request.SendRequest(onSuccess, onError);
        }

        private static Action<T, ApiLinksFormat> OmitApiLinksFormat<T>(Action<T> onSuccess)
        {
            return (data, links) => onSuccess(data);
        }
    }
}
