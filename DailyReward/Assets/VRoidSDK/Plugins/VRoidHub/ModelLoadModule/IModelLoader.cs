using System;
using UnityEngine;
using UnityEngine.Networking;
using VRM;

namespace VRoidSDK
{
    /// <summary>
    /// キャラクターモデルをロードする手法を提供するインターフェース
    /// </summary>
    public interface IModelLoader
    {
        /// <summary>
        /// 進捗状態をハンドリングするコールバック
        /// </summary>
        /// <value>進捗度 (0.0 ~ 1.0)を引数にするコールバック関数</value>
        Action<float> OnProgress { get; set; }

        /// <summary>
        /// モデルのロード時にハンドリングされるコールバック
        /// </summary>
        /// <value>エラーが発生したときの例外を引数にとるコールバック関数</value>
        Action<Exception> OnError { get; set; }

        /// <summary>
        /// VRMのインポート完了時にハンドリングされるコールバック
        /// </summary>
        /// <value>VRMから読み込まれたGameObjectを引数にとるコールバック関数</value>
        Action<GameObject> OnVrmModelLoaded { get; set; }

        /// <summary>
        /// モデルをロードする
        /// </summary>
        void Load();
    }
}
