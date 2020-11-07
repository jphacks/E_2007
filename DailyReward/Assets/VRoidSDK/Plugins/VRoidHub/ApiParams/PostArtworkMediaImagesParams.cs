using System.Collections.Generic;
using UnityEngine;
using VRoidSDK.Networking;

namespace VRoidSDK
{
    /// <summary>
    /// 画像をアップロードするパラメータ
    /// </summary>
    public class PostArtworkMediaImagesParams : IHttpParam
    {
        /// <summary>
        /// 画像ファイル
        /// </summary>
        public byte[] file;

        /// <summary>
        /// 画像に写っているキャラクターモデルID一覧
        /// </summary>
        public List<string> character_model_ids;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="file">アップロードする画像ファイルのバイト列</param>
        public PostArtworkMediaImagesParams(byte[] file)
        {
            this.file = file;
            character_model_ids = new List<string>();
        }

        public WWWForm GetParam()
        {
            WWWForm requestParams = new WWWForm();

            if (file != null)
            {
                requestParams.AddBinaryData("file", file);
            }

            if (character_model_ids != null)
            {
                foreach (var id in character_model_ids)
                {
                    requestParams.AddField("character_model_ids[]", id);
                }
            }

            return requestParams;
        }
    }
}
