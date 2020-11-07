# VRoid SDK
VRoid SDKのご利用ありがとうございます。  
本ライブラリのご利用にあたって、まず[VRoidSDK ガイドライン](https://vroid.pixiv.help/hc/ja/articles/900000213643-VRoid-SDK-ガイドライン)を必ずご一読ください。
よろしくお願いいたします。

## SDK設定
- [アプリケーション管理ページ](https://hub.vroid.com/oauth/applications)からOAuth連携アプリケーションを作成し、Application UIDとSecretを取得する
- `Assets/VRoidSDK/Plugins/SDKConfigurations/SDKConfiguration.asset`を開き、Application Id/Secret、Scopeをそれぞれ設定する
- モバイルアプリケーションの場合は、管理ページで設定したリダイレクトURIをAndroid/IOS Url Schemeにそれぞれ設定する
    - ここで設定したURLスキーマはビルド前、あるいはビルド後にプロジェクトに埋め込まれます
    - Androidの場合はアプリケーションビルド前に、`Assets/Plugins/Android/AndroidManifest.xml`にUrlスキーマに変更があれば追加されます。もし、AndroidManifestが存在しない場合`Assets/VRoidSDK/Android/AndroidManifest.xml.example`からコピーされて追加されます。詳しくは、`Assets/VRoidSDK/Editor/AndroidManifestAddUrlScheme.cs`を参照してください
    - iOSの場合はビルド完了後に、出力される`Info.plist`に埋め込まれます。詳しくは、`Assets/VRoidSDK/Editor/UrlSchemePostprocessor.cs`を参照ください

## Getting Started
### キャラクターモデルの読み込み
#### CharacterModelExampleのPrefabを使う方法
`Assets/VRoidSDK/Examples/CharacterModelExample/Prefabs/VRoidHubController`を使えば、独自にUIを作らなくてもExample相当のUIまで実現することが可能です

- `Assets/VRoidSDK/Examples/CharacterModelExample/Prefabs/VRoidHubController`PrefabをUnityのシーンに配置
- モデルが読み込まれた時の処理、言語が切り替えられたときの処理を実装するために、`CharacterModelExampleEventHandler`を継承したスクリプトを作成
    - `Assets/VRoidSDK/Examples/CharacterModelExample/Scripts/MainSystem.cs`を参考
- `VRoidHubController/Routes`の`EventHandler`に作成したスクリプトをアタッチしたゲームオブジェクトを設定
- 別途ボタンなどから`Routes.ShowCharacterModels`を実行するだけで、キャラクターモデル一覧の表示が可能 (未ログインの場合はログインダイアログが出る)
- `Routes.ShowCharacterModelProperty`で、読み込んでいるモデルのプロパティ情報を表示可能
- `Routes.ShowLoadedCharacterModel`で、読み込んでいるモデルのライセンス情報を表示可能

#### Prefabを使わない方法
[こちら](https://developer.vroid.com)を参照してください

### アートワークの読み込み、アップロード
#### ArtworkExampleのPrefabを使う方法

- `Assets/VRoidSDK/Examples/ArtworkExample/Prefabs/VRoidHubController`PrefabをUnityのシーンに配置
- 言語が切り替えられたときの処理を実装するために、`ArtworkExampleEventHandler`を継承したスクリプトを作成
    - `Assets/VRoidSDK/Examples/ArtworkExample/Scripts/MainSystem.cs`を参考
- `VRoidHubController/Routes`の`EventHandler`に作成したスクリプトをアタッチしたゲームオブジェクトを設定
- 別途ボタンなどから`Routes.ShowArtworks`を実行するだけで、自分の投稿したArtworkの一覧を表示可能 (未ログインの場合はログインダイアログが出る)
- `Routes.ShowArtworkCreateMenu`と引数にスクリーンショットを取るためのカメラを指定することで、カメラから撮影した画像を投稿するための画面を表示可能
  - ** デフォルトでは、撮影のシミュレーションモードになっているため画像のアップロードは行われません。実際にアップロードを行う際は `VRoidHubController/Routes`の`Upload Simulation` のチェックを外してください **
  - ** Artworkの投稿は公開状態で投稿が行われます。実際に投稿を行う際は細心の注意を払いつつご利用ください **

#### Prefabを使わない方法

```cs
// ログインアカウント情報を取得
HubApi.GetAccount((account) => {
  // 投稿したArtwork一覧を取得
  HubApi.GetUsersArtworks(account.user_detail.user, 10, (artworks, next) => {
      // アートワーク一覧を表示など
  }, (error) => Debug.LogError(error.message));
}, (error) => Debug.LogError(error.message));

// アートワークに画像を添付して投稿する
// fileはpngまたはjpeg画像のバイナリデータ
var param = new PostArtworkMediaImagesParams(file);
// 画像にVRoidHubモデルを紐づける場合はCharacterModel#idを設定する
param.character_model_ids.Add("1234565");
// 画像をVRoidHubにアップロード
HubApi.PostArtworkMediaImage(param, (artworkMedium) => {
    var artworkParam = new PostArtworksParams("captionの内容", EnumAgeLimit.normal, new List<string>() { artworkMedium.id });

    // アートワークの投稿
    HubApi.PostArtwork(artworkParam, (artworkDetail) => {
        // 投稿したアートワークページに飛ぶなど
    }, (error) => Debug.LogError(error.message));
}, (progress) => {
    // プログレスバーの更新など
}, (error) => Debug.LogError(error.message));
```

## API Document
[こちら](https://developer.vroid.com/sdk/docs/VRoidSDK.html)を参照してください

## サポートランタイム設定
|    Scripting Runtime Version    | Scripting Backend※ | Api Compatibility Level |
| ------------------------------- | ------------------ | ----------------------- |
| .NET 3.5 Equivalent(deprecated) |        Mono        |      .NET 2.0 Subset    |
| .NET 4.x Equivalent             |        Mono        |         .NET4.x         |

※ Android端末の場合、Scripting BackendにMonoを採用することはできません。IL2CPPをご利用ください

## サポートiOSバージョン
iOS 9.0以上

Deployment Targetを9.0以上に設定してください。
Deployment TargetはFile -> Build Setting -> Other Settings のTarget minimum iOS Versionで設定できます。

## パッケージビルドバージョン
Unity 2018.2.17f1
