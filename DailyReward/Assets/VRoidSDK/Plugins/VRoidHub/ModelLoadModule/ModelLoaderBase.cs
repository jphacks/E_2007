using System;
using UnityEngine;
using UnityEngine.Networking;
using VRM;

namespace VRoidSDK
{
    /// <summary>
    /// キャラクターモデルをシーンにロードするための基底クラス
    /// </summary>
    public abstract class ModelLoaderBase : IModelLoader
    {
        /// <summary>
        /// 進捗状態をハンドリングするコールバック
        /// </summary>
        /// <value>進捗度 (0.0 ~ 1.0)を引数にするコールバック関数</value>
        public Action<float> OnProgress { get; set; }

        /// <summary>
        /// モデルのロード時にハンドリングされるコールバック
        /// </summary>
        /// <value>エラーが発生したときの例外を引数にとるコールバック関数</value>
        public Action<Exception> OnError { get; set; }

        /// <summary>
        /// VRMのインポート完了時にハンドリングされるコールバック
        /// </summary>
        /// <value>VRMから読み込まれたGameObjectを引数にとるコールバック関数</value>
        public Action<GameObject> OnVrmModelLoaded { get; set; }

        /// <summary>
        /// モデルをロードする
        /// </summary>
        public abstract void Load();

        /// <summary>
        /// バイナリ列をVRMファイルとして読み込む
        /// </summary>
        /// <param name="characterBinary"></param>
        protected void LoadVRMFromBinary(byte[] characterBinary)
        {
            VRMImporterContext context = new VRMImporterContext();
            try
            {
                context.ParseGlb(characterBinary);
            }
            catch (Exception ex)
            {
                if (OnError != null)
                {
                    OnError(ex);
                }
                return;
            }
            context.LoadAsync(() =>
            {
                context.ShowMeshes();
                OnVrmModelLoaded(context.Root);
            },
            onError: OnError);
        }
    }
}
