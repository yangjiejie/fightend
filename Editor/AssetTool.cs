using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetTool : Editor
{
    [MenuItem("mytool/test", false, 1)]
    public static void Test()
    {
        Debug.Log("我的工具测试");
    }

    [MenuItem("mytool/AssetBundle/Set AssetBundle By Path")]
    static public void SetAssetBundleByPath()
    {
        foreach (var obj in Selection.objects)
        {
            var assetPath = AssetDatabase.GetAssetPath(obj);
            var assetImporter = AssetImporter.GetAtPath(assetPath);

            string assetBundleName = assetPath.Substring(assetPath.IndexOf("/") + 1);
            assetImporter.assetBundleName = assetBundleName;
        }
    }

    [MenuItem("mytool/获取预设的ab name")]
    public static void GetPrefabABName()
    {
        GameObject[] go = Selection.gameObjects;
        for (int i = 0; i < go.Length; i++)
        {
            var path = AssetDatabase.GetAssetPath(go[i]);
            var assetImporter = AssetImporter.GetAtPath(path);
            GUIUtility.systemCopyBuffer = assetImporter.assetBundleName;
        }
        Debug.Log("GetPrefabABName complete !!!! ");
    }

}
