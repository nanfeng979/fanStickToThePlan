using System.Collections.Generic;
using UnityEngine;

namespace Y9g
{
    public sealed class Utils
    {
        /// <summary>
        /// 16进制颜色转换为Color
        /// </summary>
        /// <param name="hex"> 16进制颜色 </param>
        /// <returns> Color 值 </returns>
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

        /// <summary>
        /// 用于二维数组，根据 direction 方向，判断下一个位置是否越界。
        /// </summary>
        /// <param name="array"> 二维数组 </param>
        /// <param name="currentIndex"> 当前位置 </param>
        /// <param name="direction"> 方向 </param>
        /// <returns> 是否越界 </returns>
        public static bool IsCrossTheBorderBy2DArray(ref List<List<int>> array, Vector2Int currentIndex, int direction)
        {
            Vector2Int nextIndex = currentIndex;

            switch (direction)
            {
                case 0:
                    nextIndex.x--;
                    break;
                case 1:
                    nextIndex.x++;
                    break;
                case 2:
                    nextIndex.y--;
                    break;
                case 3:
                    nextIndex.y++;
                    break;
            }

            if (nextIndex.x < 0 || nextIndex.x > array.Count || nextIndex.y <= 0 || nextIndex.y > array[0].Count)
            {
                return false;
            }

            return true;
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