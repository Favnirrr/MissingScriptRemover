using UnityEngine;
using UnityEditor;

public class MissingScriptRemover : EditorWindow
{
    [MenuItem("Tools/Remove Missing Scripts/Scene")]
    public static void RemoveMissingScriptsOnScene()
    {
        int count = 0;
        GameObject[] objects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (GameObjectUtility.RemoveMonoBehavioursWithMissingScript(obj) > 0)
            {
                count++;
            }
        }

        if (count > 0)
        {
            Debug.Log($"Removed {count} missing scripts.");
        }
        else
        {
            Debug.Log("No missing scripts found.");
        }
    }

    [MenuItem("Tools/Remove Missing Scripts/Prefab")]
    public static void RemoveMissingScriptsOnPrefab()
    {
        // 選択したprefabのGUIDを取得
        string[] guids = Selection.assetGUIDs;
        // 選択したprefabがない場合
        if (guids.Length == 0)
        {
            // エラーダイアログ
            EditorUtility.DisplayDialog("Error", "No prefab selected.", "OK");
            // ログ出力
            Debug.LogWarning("No prefab selected.");
            return;
        }
        // string[] allGUID = AssetDatabase.FindAssets("t:prefab");

        // 削除したコンポーネントのカウンター
        int count = 0;

        for(int i=0;i<guids.Length;i++){
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            GameObject prefabInstance = PrefabUtility.LoadPrefabContents(path);
            if (prefabInstance != null)
            {
                // 子オブジェクトを取得する
                var parentAndChildren = prefabInstance.GetComponentsInChildren<Transform>(true);
                foreach(Transform Tsf in parentAndChildren){
                    Debug.Log(Tsf.gameObject.name);
                    if (GameObjectUtility.RemoveMonoBehavioursWithMissingScript(Tsf.gameObject) > 0)
                    {
                        count++;
                    }
                }
                PrefabUtility.SaveAsPrefabAsset(prefabInstance, path);
                PrefabUtility.UnloadPrefabContents(prefabInstance);
            }
        }
        AssetDatabase.Refresh();
        
        Debug.Log($"Removed {count} Missing Scripts On Selected Prefab.");
    }
}
