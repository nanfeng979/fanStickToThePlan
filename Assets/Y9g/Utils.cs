using UnityEngine;

namespace Y9g
{
    public sealed class Utils
    {
        public static Color HexToColor(string hex)
        {
            Color color = Color.white;
            if (ColorUtility.TryParseHtmlString(hex, out color))
            {
                return color;
            }
            else
            {
                Debug.LogError("HexToColor: " + hex);
                return Color.white;
            }
        }
    }

    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance { get; private set; }

        protected void Awake()
        {
            if (Instance == null)
            {
                Instance = (T) this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogWarning("单例模式，已经存在一个实例。");
                // Destroy(gameObject);
            }
        }
    }

    public class Singleton_sub<T> : MonoBehaviour where T : Singleton_sub<T>
    {
        public static T Instance { get; private set; }

        protected void Awake()
        {
            Instance = (T) this;
        }
    }
}