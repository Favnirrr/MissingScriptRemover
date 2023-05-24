# MissingScriptRemover
Unityのアクティブなシーン内GameObject、及びPrefabの、missingになっているScriptコンポーネントを自動的に削除するEditor拡張です。

前提スクリプトが必要なアセット・プレハブを使用する際に、missingによるPlayモードが開けない問題や、前提スクリプトを使用せず開発をする際の効率化を図る目的で作成しました。
（VRChat向けアバターアセットのプレハブをVRChat向けプロジェクト以外で利用したいときなど）

## 使用方法
1. 上部メニューバーにあるメニューアイテム「Tools/Remove Missing Scripts」を選択
2. シーン内gameObjectの検査をしたい場合は「Scenes」、
   Prefabの検査をしたい場合は**アセットファイル**（**Projectウィンドウのファイル**）を選択した後、「Prefab」を選択してください。
3. Consoleに「Removed {count} missing scripts.」と表示されます。
   削除したコンポーネントの数が合わせて表記されます。0となっている場合はスクリプトの削除を行っていないため、確認を行ってください。
