using System;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Networking;
using VRM;
using VRoidSDK.OAuth;


namespace VRoidSDK
{
    /// <summary>
    /// VRoid Hubからキャラクターモデルをダウンロードしてモデルをロードする
    /// </summary>
    public class ModelDownloadLoader : ModelLoaderBase
    {
        public delegate void Action<T1, T2, T3, T4, T5>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5);

        private DownloadLicense _license;
        private IModelSavable _modelSaveModule;
        private Action<string, int, Action<byte[]>, Action<float>, Action<ApiErrorFormat>> _downloadFunc;
        private int _timeout;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="license">ダウンロードライセンス</param>
        /// <param name="save">モデルを保存する機能を提供するモジュール</param>
        /// <param name="auth">認証機能を持ったモジュール</param>
        /// <param name="timeout">ダウンロードのタイムアウト(秒)</param>
        public ModelDownloadLoader(DownloadLicense license, IModelSavable save, Action<string, int, Action<byte[]>, Action<float>, Action<ApiErrorFormat>> downloadFunc, int timeout)
        {
            _license = license;
            _modelSaveModule = save;
            _downloadFunc = downloadFunc;
            _timeout = timeout;
        }

        /// <summary>
        /// モデルをロードする
        /// </summary>
        public override void Load()
        {
            _downloadFunc(_license.id, _timeout, OnDownloadSuccess, OnProgress, OnDownloadError);
        }

        private void OnDownloadSuccess(byte[] downloadBinary)
        {
            if (IsGzipBinary(downloadBinary))
            {
                downloadBinary = DecompressGzipBinary(downloadBinary);
            }
            var baseVrmLoadCallback = base.OnVrmModelLoaded;
            OnVrmModelLoaded = (context) =>
            {
                _modelSaveModule.Save(_license, downloadBinary);
                baseVrmLoadCallback(context);
            };
            LoadVRMFromBinary(downloadBinary);
        }

        private void OnDownloadError(ApiErrorFormat error)
        {
            if (OnError != null)
            {
                OnError(new Exception(error.code + ": " + error.message));
            }
        }

        private bool IsGzipBinary(byte[] binary)
        {
            return binary.Length > 2 && binary[0] == 0x1F && binary[1] == 0x8B;
        }

        private byte[] DecompressGzipBinary(byte[] gzipBinary)
        {
            var buffer = new byte[4096];
            using (var memoryStream = new System.IO.MemoryStream(gzipBinary))
            using (var outputMemoryStream = new System.IO.MemoryStream())
            using (var gzStream = new GZipStream(memoryStream, CompressionMode.Decompress))
            {
                int bytesRead = -1;
                while ((bytesRead = gzStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    outputMemoryStream.Write(buffer, 0, bytesRead);
                }
                return outputMemoryStream.ToArray();
            }
        }
    }
}
