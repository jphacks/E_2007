using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using VRoidSDK;
using VRoidSDK.OAuth;

namespace VRoidSDK
{
    public partial class SDKConfiguration : ScriptableObject
    {
        [Serializable]
        public partial class ScopeKind
        {
            [Tooltip("標準で使えるAPIを実行できます。\n(例) キャラクターモデルのダウンロード")]
            [SerializeField]
            public bool Default;
            [Tooltip("ハートに関する機能が使えるAPIを実行できます。\n(例) ハートをモデルにつける")]
            [SerializeField]
            public bool Heart;
        }

        [Tooltip("OAuthのアプリケーションIDを設定します。\nアプリケーション管理ページからOAuthの連携アプリケーションを作成し、作成したApplicationIdを入力してください")]
        [FormerlySerializedAs("ApplicationId")]
        [SerializeField]
        private string _applicationId;

        [Tooltip("OAuthのシークレットキーを設定します。\nアプリケーション管理ページからOAuthの連携アプリケーションを作成し、作成したSecretを入力してください")]
        [FormerlySerializedAs("Secret")]
        [SerializeField]
        private string _secret;

        [Tooltip("Android用のURLスキームを設定します。\nOAuthの連携アプリケーション作成画面のリダイレクトURIで設定した項目を入力します。\nリダイレクトURIにURLスキーマを設定していない場合は空文字にしてください")]
        public string AndroidUrlScheme;
        [Tooltip("iOS用のURLスキームを設定します。\nOAuthの連携アプリケーション作成画面のリダイレクトURIで設定した項目を入力します。\nリダイレクトURIにURLスキーマを設定していない場合は空文字にしてください")]
        public string IOSUrlScheme;
        [Tooltip("API実行用のスコープを設定します。このスコープにより使えるAPIを変更できます")]
        public ScopeKind Scope;

        /// <summary>
        /// VRoid Hubアプリケーションのメタ情報を取得する
        /// </summary>
        /// <value>メタ情報</value>
        public AuthenticateMetaData AuthenticateMetaData
        {
            get
            {
                if (_metaData == null)
                {
#if !UNITY_EDITOR && UNITY_IOS
                    IAuthenticateSession session = new AuthenticateSessionIOS();
#else
                    IAuthenticateSession session = new AuthenticateSessionDefault();
#endif

                    _metaData = new AuthenticateMetaData(_applicationId.Trim(), _secret.Trim(), session);
                }

                return _metaData;
            }
        }
        private AuthenticateMetaData _metaData = null;

        /// <summary>
        /// スコープ設定を元に、連結したスコープパラメータを取得する
        /// </summary>
        /// <returns>空文字で連結されたスコープパラメータ</returns>
        public string JoinScope()
        {
            var typeInfo = typeof(ScopeKind).GetFields();
            var joinedScope = typeInfo.Select<FieldInfo, string>((props, _) =>
            {
                if ((bool)props.GetValue(Scope) == true)
                {
                    return props.Name.ToLower();
                }
                else
                {
                    return "";
                }
            }).Aggregate((a, b) => a + " " + b);
            return joinedScope.TrimEnd();
        }
    }
}
