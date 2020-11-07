using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using VRM;

namespace VRoidSDK
{
    /// <summary>
    /// VRoid Hubのキャラクターを3Dモデルとして読み込む機能を提供するシングルトン
    /// </summary>
    public class HubModelDeserializer : MonoBehaviour, ICoroutineHandlable
    {
        // Singleton
        private static HubModelDeserializer s_instance;

        /// <summary>
        /// シングルトンオブジェクトを取り出す
        /// </summary>
        public static HubModelDeserializer Instance
        {
            get
            {
                if (HubModelDeserializer.s_instance == null)
                {
                    GameObject gameObject = new GameObject(Guid.NewGuid().ToString());
                    DontDestroyOnLoad(gameObject);
                    HubModelDeserializer.s_instance = gameObject.AddComponent<HubModelDeserializer>();
                }
                return HubModelDeserializer.s_instance;
            }
        }

        /// <summary>
        /// 廃止予定: VRoid HubのキャラクターモデルIDからキャラクターモデルのGameObjectを取得する
        /// </summary>
        /// <remarks>
        /// 初めて取り込むキャラクターモデルは、VRoidHubApi経由でモデルデータをダウンロードし、LocalStorageにキャッシュされる。
        /// 一度取り込まれたキャラクターモデルは、次からキャッシュから読み込まれるようになる
        /// </remarks>
        /// <param name="characterModelId">取り出すキャラクターモデルID</param>
        /// <param name="maxCacheCount">最大で保持するキャッシュの数</param>
        /// <param name="onLoadComplete">キャラクターモデルの読み込みに成功した時のコールバック</param>
        /// <param name="onDownloadProgress">ダウンロードの進捗状況を通知するコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        [Obsolete("Deprecated. Please use the method that first argument type is CharacterModel.", false)]
        public void LoadCharacterAsync(string characterModelId,
                                        uint maxCacheCount,
                                        Action<GameObject> onLoadComplete,
                                        Action<float> onDownloadProgress,
                                        Action<Exception> onError)
        {
            HubApi.GetCharacterModel(characterModelId, (CharacterModelDetail) =>
            {
                var option = new HubModelDeserializerOption();
                option.MaxCacheCount = maxCacheCount;
                LoadCharacterAsync(
                    CharacterModelDetail.character_model,
                    option,
                    onLoadComplete,
                    onDownloadProgress,
                    onError
                );
            },
            (ApiErrorFormat errorFormat) =>
            {
                onError(new Exception(errorFormat.message));
            });
        }

        /// <summary>
        /// VRoid HubのキャラクターモデルからキャラクターモデルのGameObjectを取得する
        /// </summary>
        /// <remarks>
        /// 初めて取り込むキャラクターモデルは、VRoidHubApi経由でモデルデータをダウンロードし、LocalStorageにキャッシュされる。
        /// 一度取り込まれたキャラクターモデルは、次からキャッシュから読み込まれるようになる
        /// </remarks>
        /// <param name="characterModel">取り出すキャラクターモデル</param>
        /// <param name="option">オプション</param>
        /// <param name="onLoadComplete">キャラクターモデルの読み込みに成功した時のコールバック</param>
        /// <param name="onDownloadProgress">ダウンロードの進捗状況を通知するコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        public void LoadCharacterAsync(CharacterModel characterModel,
                                        HubModelDeserializerOption option,
                                        Action<GameObject> onLoadComplete,
                                        Action<float> onDownloadProgress,
                                        Action<Exception> onError)
        {
            ModelLoaderFactory.Create(characterModel, this, option, (loader) =>
            {
                loader.OnVrmModelLoaded = onLoadComplete;
                loader.OnProgress = onDownloadProgress;
                loader.OnError = onError;
                loader.Load();
            }, (ApiErrorFormat errorFormat) =>
            {
                onError(new ApiRequestFailException(errorFormat));
            });
        }

        /// <summary>
        /// 廃止予定: VRoid HubのキャラクターモデルIDからキャラクターモデルのGameObjectを取得する
        /// </summary>
        /// <remarks>
        /// 初めて取り込むキャラクターモデルは、VRoidHubApi経由でモデルデータをダウンロードし、LocalStorageにキャッシュされる。
        /// 一度取り込まれたキャラクターモデルは、次からキャッシュから読み込まれるようになる (最大10件までキャッシュを保持します。)
        /// </remarks>
        /// <param name="characterModelId">取り出すキャラクターモデルID</param>
        /// <param name="onLoadComplete">キャラクターモデルの読み込みに成功した時のコールバック</param>
        /// <param name="onDownloadProgress">ダウンロードの進捗状況を通知するコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        [Obsolete("Deprecated. Please use the method that first argument type is CharacterModel.", false)]
        public void LoadCharacterAsync(string characterModelId,
                                        Action<GameObject> onLoadComplete,
                                        Action<float> onDownloadProgress,
                                        Action<Exception> onError)
        {
            LoadCharacterAsync(characterModelId, 10, onLoadComplete, onDownloadProgress, onError);
        }

        /// <summary>
        /// VRoid HubのキャラクターモデルからキャラクターモデルのGameObjectを取得する
        /// </summary>
        /// <remarks>
        /// 初めて取り込むキャラクターモデルは、VRoidHubApi経由でモデルデータをダウンロードし、LocalStorageにキャッシュされる。
        /// 一度取り込まれたキャラクターモデルは、次からキャッシュから読み込まれるようになる
        /// </remarks>
        /// <remarks>
        /// オプションはデフォルト値 (キャッシュの最大10件、ダウンロードのタイムアウト300秒)
        /// </remarks>
        /// <param name="characterModel">取り出すキャラクターモデル</param>
        /// <param name="onLoadComplete">キャラクターモデルの読み込みに成功した時のコールバック</param>
        /// <param name="onDownloadProgress">ダウンロードの進捗状況を通知するコールバック</param>
        /// <param name="onError">エラー発生時のコールバック</param>
        public void LoadCharacterAsync(CharacterModel characterModel,
                                        Action<GameObject> onLoadComplete,
                                        Action<float> onDownloadProgress,
                                        Action<Exception> onError)
        {
            LoadCharacterAsync(characterModel, new HubModelDeserializerOption(), onLoadComplete, onDownloadProgress, onError);
        }

        /// <summary>
        /// コルーチン処理を実行する
        /// </summary>
        /// <param name="routine">処理するコルーチン</param>
        public void RunMonoCoroutine(IEnumerator routine)
        {
            StartCoroutine(routine);
        }
    }
}
