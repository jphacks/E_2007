using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRoidSDK
{
    /// <summary>
    /// キャッシュからモデルを読み取る
    /// </summary>
    public class ModelCachedLoader : ModelLoaderBase
    {
        private ICoroutineHandlable _coroutineHandler;
        private DownloadLicense _license;
        private ITaskQueue _taskQueue;
        private IModelLoadable _modelLoadModule;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="license">キャッシュ化されたライセンス情報</param>
        /// <param name="coroutine">コルーチンが実行できるハンドラオブジェクト</param>
        /// <param name="taskQueue">非同期処理をキューを使って実行できる機能を持ったモジュール</param>
        /// <param name="decryptFunc">復号処理を行う関数</param>
        public ModelCachedLoader(DownloadLicense license, ICoroutineHandlable coroutine, ITaskQueue taskQueue, IModelLoadable loadModule)
        {
            _license = license;
            _coroutineHandler = coroutine;
            _taskQueue = taskQueue;
            _modelLoadModule = loadModule;
        }

        /// <summary>
        /// キャッシュからモデルをロードする
        /// </summary>
        public override void Load()
        {
            _coroutineHandler.RunMonoCoroutine(LoadAsyncCachedBinary(_license));
        }

        private IEnumerator LoadAsyncCachedBinary(DownloadLicense license)
        {
            byte[] binary = new byte[] { };
            Exception exception = null;
            _taskQueue.Enqueue(() =>
            {
                try
                {
                    binary = _modelLoadModule.Load(license);
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });

            yield return WaitFor();

            if (OnProgress != null)
            {
                OnProgress(1.0f);
            }

            if (exception == null)
            {
                LoadVRMFromBinary(binary);
            }
            else if (OnError != null)
            {
                OnError(exception);
            }
        }

        private IEnumerator WaitFor()
        {
            while (_taskQueue.ExistQueueEvent)
            {
                yield return null;
            }
        }
    }
}
