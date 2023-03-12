using UnityEngine;
using UnityEditor;

public class MissingScriptRemover : EditorWindow
{
    [MenuItem("Tools/Remove Missing Scripts")]
    public static void RemoveMissingScripts()
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
}
