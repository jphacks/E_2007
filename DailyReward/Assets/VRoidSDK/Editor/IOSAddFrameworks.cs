using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
#if UNITY_IOS
using UnityEditor.iOS.Xcode;
#endif

namespace VRoidSDK.Editor
{
    public class IOSAddFrameworks
    {
        [PostProcessBuild]
        public static void OnPostProcessBuild(BuildTarget buildTarget, string path)
        {
            if (buildTarget == BuildTarget.iOS)
            {
                ProcessForiOS(path);
            }
        }

        private static void ProcessForiOS(string path)
        {
#if UNITY_IOS
            string pjPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";
            PBXProject pj = new PBXProject();
            pj.ReadFromString(File.ReadAllText(pjPath));

            string guid;
#if UNITY_2019_3_OR_NEWER
            guid = pj.GetUnityFrameworkTargetGuid();
#else
            var targetName = PBXProject.GetUnityTargetName();
            guid = pj.TargetGuidByName(targetName);
#endif

            pj.AddFrameworkToProject(guid, "SafariServices.framework", false);
            pj.AddFrameworkToProject(guid, "AuthenticationServices.framework", false);
            File.WriteAllText(pjPath, pj.WriteToString());
#endif
        }
    }
}
