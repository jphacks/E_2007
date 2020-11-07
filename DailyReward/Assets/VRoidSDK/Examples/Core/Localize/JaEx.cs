using System.Collections.Generic;
using VRoidSDK.Localize;

namespace VRoidSDK.Examples.Core.Localize
{
    public class JaEx : Ja
    {
        private static readonly Dictionary<string, string> s_localeDictionary = new Dictionary<string, string>()
        {
            { ExampleViewKey.ViewLoginAuthorizationCode, "認可コード" },
            { ExampleViewKey.ViewLoginLoginConnect, "VRoid Hub に接続" },
            { ExampleViewKey.ViewLoginLogin, "ログイン" },
            { ExampleViewKey.ViewLoginLogout, "ログアウト" },
            { ExampleViewKey.ViewLoginConnectionFailureMessage, "接続失敗" },
            { ExampleViewKey.ViewLoginLoginFailureMessage, "ログイン失敗" },
            { ExampleViewKey.ViewCharacterModelDetailAcceptLicense, "利用条件に従って利用する" },
            { ExampleViewKey.ViewCharacterModelDetailModelUse, "利用する" },
            { ExampleViewKey.ViewCharacterModelDetailModelUseCancel, "キャンセル" },
            { ExampleViewKey.ViewCharacterModelDetailLoading, "読込中" },
            { ExampleViewKey.ViewCharacterModelPropertyTitle, "モデル情報" },
            { ExampleViewKey.ViewCharacterModelPropertyModelId, "モデルのId" },
            { ExampleViewKey.ViewCharacterModelPropertySpecVersion, "Spec Version" },
            { ExampleViewKey.ViewCharacterModelPropertyExporterVersion, "Exporter Version" },
            { ExampleViewKey.ViewCharacterModelPropertyTriangleCount, "三角ポリゴン数" },
            { ExampleViewKey.ViewCharacterModelPropertyMeshCount, "メッシュ数" },
            { ExampleViewKey.ViewCharacterModelPropertyMeshPrimitiveCount, "サブメッシュ数" },
            { ExampleViewKey.ViewCharacterModelPropertyMeshPrimitiveMorphCount, "モーフ数" },
            { ExampleViewKey.ViewCharacterModelPropertyTextureCount, "テクスチャ数" },
            { ExampleViewKey.ViewCharacterModelPropertyJointCount, "ジョイント数" },
            { ExampleViewKey.ViewCharacterModelPropertyMaterialCount, "マテリアル数" },
            { ExampleViewKey.ViewCharacterModelPropertyCloseButton, "閉じる" },
            { ExampleViewKey.ViewArtworkDetailCloseButton, "閉じる" },
            { ExampleViewKey.ViewArtworkCreateTitle, "写真を投稿" },
            { ExampleViewKey.ViewArtworkCreateSimulation, "※シミュレーションモードの場合はアップロードは行われません. Uploadを試す場合は、RoutesのUpload Simulationのチェックを外してください" },
            { ExampleViewKey.ViewArtworkCreateCaption, "キャプション" },
            { ExampleViewKey.ViewArtworkCreateAgeLimit, "閲覧制限" },
            { ExampleViewKey.ViewArtworkCreateAgeLimitAll, "全年齢" },
            { ExampleViewKey.ViewArtworkCreateAgeLimitR15, "R-15" },
            { ExampleViewKey.ViewArtworkCreateAgeLimitR18, "R-18" },
            { ExampleViewKey.ViewArtworkCreateUpload, "投稿する" },
            { ExampleViewKey.ViewArtworkCreateCancel, "キャンセル" },
        };

        public override string Get(string key)
        {
            if (s_localeDictionary.ContainsKey(key))
            {
                return s_localeDictionary[key];
            }

            return base.Get(key);
        }
    }
}
