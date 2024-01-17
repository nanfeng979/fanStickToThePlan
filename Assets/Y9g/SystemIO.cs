using UnityEngine;

namespace Y9g
{
    public sealed class SystemIO
    {
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

        public static string ReadJsonFileFromStreamingAssets(string fileName)
        {
            string result = string.Empty;
            result = ReadFileFromStreamingAssets(fileName + ".json");

            return result;
        }
    }
}