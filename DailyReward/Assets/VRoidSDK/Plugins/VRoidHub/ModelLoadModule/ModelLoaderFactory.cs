using System;
using UnityEngine;
using VRoidSDK.OAuth;

namespace VRoidSDK
{
    /// <summary>
    /// 状況に応じてモデルをロードするモジュールを作成するファクトリー
    /// </summary>
    /// <remarks>
    /// ファイルがすでにキャッシュ上に存在する場合は、キャッシュからロードするモジュールを作成し、
    /// 存在しない場合は、HubApiを実行してダウンロードしてからロードするモジュールを作成する
    /// </remarks>
    public static class ModelLoaderFactory
    {
        /// <summary>
        /// モデルをロードするモジュールを作成する
        /// </summary>
        /// <param name="characterModel">ロードするキャラクターモデル</param>
        /// <param name="coroutineHandler">コルーチンが実行できるハンドラオブジェクト</param>
        /// <param name="option">オプション</param>
        /// <param name="onSuccess">成功時のコールバック関数</param>
        /// <param name="onError">失敗時のコールバック関数</param>
        public static void Create(CharacterModel characterModel, ICoroutineHandlable coroutineHandler, HubModelDeserializerOption option, Action<IModelLoader> onSuccess, Action<ApiErrorFormat> onError)
        {
            CachedLicense? oldCachedLicense = LicenseManager.LoadExistLicense(characterModel.id);
            if (oldCachedLicense != null && oldCachedLicense.Value.IsAvailable(characterModel))
            {
                var loadModule = new EncryptModelLoad(EncryptionModelFile.ReadBytes);
                onSuccess(new ModelCachedLoader(oldCachedLicense.Value.downloadLicense, coroutineHandler, UnityThreadQueue.Instance, loadModule));
                return;
            }


            HubApi.PostDownloadLicense(
                characterModelId: characterModel.id,
                onSuccess: (DownloadLicense license) =>
                {
                    // キャッシュに以前のファイルが残っている場合はライセンスの更新だけをしてファイルのダウンロードはしない
                    if (oldCachedLicense != null && oldCachedLicense.Value.IsSameModel(license))
                    {
                        var cachedLicense = oldCachedLicense.Value;
                        cachedLicense.UpdateDownloadLicense(license);
                        cachedLicense.Save();
                        var loadModule = new EncryptModelLoad(EncryptionModelFile.ReadBytes);
                        onSuccess(new ModelCachedLoader(license, coroutineHandler, UnityThreadQueue.Instance, loadModule));
                        return;
                    }

                    // 新しいモデルデータが保存される前に処理するので-1する必要がある
                    var cacheCount = option.MaxCacheCount - 1;
                    if (cacheCount > 0)
                    {
                        LicenseManager.CleanCache(cacheCount);
                    }
                    var saveModule = new EncryptModelSave(EncryptionModelFile.WriteBytes, EncryptionModelFile.DeleteFile);
                    onSuccess(new ModelDownloadLoader(license, saveModule, HubApi.GetDownloadLicenseDownload, option.DownloadTimeout));
                },
                onError: onError
            );
        }
    }
}
