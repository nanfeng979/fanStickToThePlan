using UnityEngine;

namespace Y9g
{
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
}