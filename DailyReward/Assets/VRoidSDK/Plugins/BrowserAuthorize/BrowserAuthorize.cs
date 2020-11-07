using UnityEngine;
using System;
using System.Text;
using System.Security.Cryptography;
using VRoidSDK.OAuth;

namespace VRoidSDK
{
    /// <summary>
    /// ブラウザを開き、アプリケーションの認証を行うためのクラス
    /// </summary>
    public class BrowserAuthorize : MonoBehaviour
    {
        private SDKConfiguration _sdkConfiguration;
        private Action<bool> _onRegistered = null;
        private string _state = null;
        private string _codeVerifier = null;

        /// <summary>
        /// ブラウザ認証用のGameObjectインスタンスを作成する
        /// </summary>
        /// <param name="sdkConfig">アプリケーションの設定情報</param>
        /// <returns>ブラウザ認証インスタンス</returns>
        public static BrowserAuthorize GenerateInstance(SDKConfiguration sdkConfig)
        {
            var gameObjectName = "BrowserAuthorize";
            var oldInstance = GameObject.Find(gameObjectName);
            if (oldInstance != null)
            {
                Destroy(oldInstance);
            }

            GameObject instanceGo = new GameObject(gameObjectName);
            GameObject.DontDestroyOnLoad(instanceGo);
            var ba = instanceGo.AddComponent<BrowserAuthorize>();
            ba._sdkConfiguration = sdkConfig;
            ba._codeVerifier = Guid.NewGuid().ToString() + "_" + Guid.NewGuid().ToString();
            ba._state = Guid.NewGuid().ToString();

            return ba;
        }

#if UNITY_ANDROID && !UNITY_EDITOR
        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus) {
                return;
            }

            using(AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using(AndroidJavaObject activity = unity.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                if (activity == null)
                {
                    CallOnRegistered(false);
                    return;
                }

                using (AndroidJavaObject intent = activity.Call<AndroidJavaObject>("getIntent"))
                {
                    if (intent == null){
                        CallOnRegistered(false);
                        return;
                    }

                    using (AndroidJavaObject intentUri = intent.Call<AndroidJavaObject>("getData"))
                    {

                        if (intentUri == null)
                        {
                            CallOnRegistered(false);
                            return;
                        }

                        var appUrl = intentUri.Call<string>("toString");
                        OnOpenUrl(appUrl);
                    }
                }
            }
        }
#endif

        /// <summary>
        /// OAuth認証後のリダイレクト先
        /// </summary>
        public string RedirectUri
        {
            get
            {
#if UNITY_EDITOR
                return "urn:ietf:wg:oauth:2.0:oob";
#elif UNITY_ANDROID
                return _sdkConfiguration.AndroidUrlScheme;
#elif UNITY_IOS
                return _sdkConfiguration.IOSUrlScheme;
#else
                return "urn:ietf:wg:oauth:2.0:oob";
#endif
            }
        }

        /// <summary>
        /// OAuthの認証コードを発行するためにブラウザを開く
        /// </summary>
        /// <param name="onRegistered">登録完了後のコールバック関数</param>
        public void OpenBrowser(Action<bool> onRegistered)
        {
            _onRegistered = onRegistered;
            var scopedText = _sdkConfiguration.JoinScope();
            Authentication.Instance.BrowserAuthorized(this.RedirectUri, scopedText, _state, GetCodeChallenge());
        }

        /// <summary>
        /// URLスキーマによりリダイレクトされたときに呼び出されるメソッド.
        /// パスに埋め込まれている認可コードを取り出して、登録を行う
        /// </summary>
        /// <param name="url">リダイレクトURL</param>
        /// <remarks>
        /// このメソッドはiOSのネイティブプラグインからOAuthの認証コードを受け取る時にも利用される
        /// </remarks>
        public void OnOpenUrl(string url)
        {
            if (!IsOAuthCallbackUrl(url))
            {
                CallOnRegistered(false);
                return;
            }

            string authCode = "";
            string state = "";
            string[] pathQuery = url.Split('?');
            if (pathQuery.Length > 1)
            {
                string[] urlQueryPairs = pathQuery[pathQuery.Length - 1].Split('&');
                for (int i = 0; i < urlQueryPairs.Length; ++i)
                {
                    string[] keyValue = urlQueryPairs[i].Split('=');
                    if (keyValue.Length > 1)
                    {
                        switch (keyValue[0])
                        {
                            case "code":
                                authCode = keyValue[1];
                                break;
                            case "state":
                                state = keyValue[1];
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            if (state != _state)
            {
                CallOnRegistered(false);
                return;
            }

            if (string.IsNullOrEmpty(authCode))
            {
                CallOnRegistered(false);
                return;
            }

            RegisterCode(authCode);
            Authentication.Instance.OnCompleteBrowseAuthorize();
        }

        /// <summary>
        /// ブラウザ認証がキャンセルされたときに呼ばれるメソッド
        /// </summary>
        /// <param name="_message">メッセージ</param>
        /// <remarks>
        /// このメソッドはiOSのネイティブプラグインからOAuthの認証コードがキャンセルされたときに利用される
        /// </remarks>
        public void OnCancelAuthorize(string _message)
        {
            CallOnRegistered(false);
            Authentication.Instance.OnCompleteBrowseAuthorize();
        }

        /// <summary>
        /// 認可コードを登録する
        /// </summary>
        /// <param name="authCode">登録する認可コード</param>
        public void RegisterCode(string authCode)
        {
            Authentication.Instance.RegisterCode(authCode, this.RedirectUri, _codeVerifier, (bool isSuccess) =>
            {
                CallOnRegistered(isSuccess);
                if (isSuccess)
                {
                    Destroy(this.gameObject);
                }
            });
        }

        private void CallOnRegistered(bool isSuccess)
        {
            if (_onRegistered != null)
            {
                _onRegistered(isSuccess);
            }
        }

        private bool IsOAuthCallbackUrl(string url)
        {
            var urlStrings = url.Split('?');
            return urlStrings.Length > 0 && RedirectUri == urlStrings[0];
        }

        private string GetCodeChallenge()
        {
            using (var sha256 = SHA256.Create())
            {
                var challengeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(_codeVerifier));
                return Base64UrlEncode(challengeBytes);
            }
        }

        // https://tools.ietf.org/html/rfc7636#appendix-A
        private string Base64UrlEncode(byte[] arg)
        {
            string s = Convert.ToBase64String(arg); // Regular base64 encoder
            s = s.Split('=')[0]; // Remove any trailing '='s
            s = s.Replace('+', '-'); // 62nd char of encoding
            s = s.Replace('/', '_'); // 63rd char of encoding
            return s;
        }
    }
}
