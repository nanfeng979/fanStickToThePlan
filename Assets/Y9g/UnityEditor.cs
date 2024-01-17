using UnityEditor;
using UnityEngine;

namespace Y9g
{
    public sealed class UnityEditor
    {
        internal static void SaveToAssets(GameObject gameObj, string prefabPath)
        {
            if (gameObj == null)
            {
                Debug.LogError("GameObject is null.");
                return;
            }

            if (prefabPath == null)
            {
                string randomName = System.Guid.NewGuid().ToString();
                prefabPath = "Assets/Temp/" + randomName + ".prefab";
            }
            
            // 使用PrefabUtility.SaveAsPrefabAsset方法保存GameObject为预制体
            PrefabUtility.SaveAsPrefabAsset(gameObj, prefabPath);
        }
    }
}