using UnityEditor;
using VRoidSDK;
using VRoidSDK.Editor;

[CustomEditor(typeof(SDKConfiguration), true)]
public sealed class SDKConfigurationInspector : Editor
{
    private SDKConfiguration _configuration;

    private void OnEnable()
    {
        //SDKConfigurationを取得
        _configuration = (SDKConfiguration)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var isError = false;
        var authenticateMetaDataValidator = new AuthenticateMetaDataValidator(_configuration);
        var iOSUriSchemeValidator = new IOSUriSchemeValidator(_configuration);
        var androidUriSchemeValidator = new AndroidUriSchemeValidator(_configuration);

        if (!authenticateMetaDataValidator.Validate())
        {
            EditorGUILayout.HelpBox("アプリケーションID, またはシークレットキーが空欄になっています", MessageType.Error);
            isError = true;
        }

        if (!iOSUriSchemeValidator.Validate())
        {
            EditorGUILayout.HelpBox("iOSのURLスキーマが不正です。\nURLとして認識できないもの、または `my-vroidsdk-app` をスキームに利用するURLは使用できません", MessageType.Error);
            isError = true;
        }

        if (!androidUriSchemeValidator.Validate())
        {
            EditorGUILayout.HelpBox("AndroidのURLスキーマが不正です。\nURLとして認識できないもの、または `my-vroidsdk-app` をスキームに利用するURLは使用できません", MessageType.Error);
            isError = true;
        }

        if (!isError)
        {
            EditorGUILayout.HelpBox("全ての設定が正常です", MessageType.Info);
        }
    }
}
