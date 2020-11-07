using UnityEditor;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using VRoidSDK;

namespace VRoidSDK.Editor
{
    public class UrlSchemeEditTool
    {
        public static SDKConfiguration LoadSDKConfiguration()
        {
            string[] paths = AssetDatabase.GetAllAssetPaths();
            for (int i = 0; i < paths.Length; ++i)
            {
                SDKConfiguration sdkConfiguration = AssetDatabase.LoadAssetAtPath<SDKConfiguration>(paths[i]);
                if (sdkConfiguration != null)
                {
                    return sdkConfiguration;
                }
            }
            return null;
        }
    }
}
