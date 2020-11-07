using System;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Callbacks;
using VRoidSDK;

namespace VRoidSDK.Editor
{
    public class AndroidManifestAddUrlScheme : IPreprocessBuildWithReport
    {
        public int callbackOrder { get; private set; }
        public void OnPreprocessBuild(BuildReport report)
        {
            if (report.summary.platform == BuildTarget.Android)
            {
                ProcessForAndroidUrlScheme();
            }
        }

        private void ProcessForAndroidUrlScheme()
        {
            if (!AndroidManifestFile.IsFileExists())
            {
                AndroidManifestFile.CopyFromExample();
            }

            var manifestXml = AndroidManifestFile.MakeManifestXml();
            SDKConfiguration sdkConfiguration = UrlSchemeEditTool.LoadSDKConfiguration();
            if (sdkConfiguration == null)
            {
                return;
            }

            var urlScheme = sdkConfiguration.AndroidUrlScheme;
            var Validator = new UriSchemeValidator(urlScheme);
            if (!Validator.Validate())
            {
                Debug.LogError("AndroidのURLスキーマが不正なのでURLスキーマの追加処理をスキップしました");
                return;
            }

            Uri uri;
            try
            {
                uri = new Uri(urlScheme);
            }
            catch (UriFormatException)
            {
                return;
            }

            manifestXml.UpdateUrlScheme(uri);
            manifestXml.Save(AndroidManifestFile.AndroidManifestPath);
        }
    }
}
