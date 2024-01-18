using UnityEngine;

namespace Y9g
{
    public sealed class SystemIO
    {
        #region Json
        public static string ReadJsonFromStreamingAssets(string fileName)
        {
            string result = string.Empty;
            result = ReadFileFromStreamingAssets(fileName + ".json");

            return result;
        }

        public static T ReadJsonFromStreamingAssets<T>(string fileName)
        {
            T result = default(T);
            string json = ReadFileFromStreamingAssets(fileName + ".json");
            if (!string.IsNullOrEmpty(json))
            {
                result = ReadJson<T>(json);
            }

            return result;
        }

        public static T ReadJsonFromStreamingAssetsWithSystemSelf<T>(string fileName)
        {
            T result = default(T);
            string json = ReadFileFromStreamingAssets(fileName + ".json");
            if (!string.IsNullOrEmpty(json))
            {
                result = ReadJsonWithSystemSelf<T>(json);
            }

            return result;
        }

        public static string ReadFileFromStreamingAssets(string fileName)
        {
            string result = string.Empty;
            string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
            if (System.IO.File.Exists(filePath))
            {
                result = System.IO.File.ReadAllText(filePath);
            }
            else
            {
                Debug.LogError("File not found: " + filePath);
            }

            return result;
        }

        public static T ReadJson<T>(string jsonString)
        {
            T jsonData = JsonUtility.FromJson<T>(jsonString);
            return jsonData;
        }

        public static T ReadJsonWithSystemSelf<T>(string jsonString)
        {
            JsonData<T> jsonData = JsonUtility.FromJson<JsonData<T>>(jsonString);
            return jsonData.data;
        }

        [System.Serializable]
        public class JsonData<T>
        {
            public T data;
        }
        #endregion Json
    }
}