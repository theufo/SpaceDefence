using UnityEngine;

namespace DefaultNamespace.Common
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;

        protected void Awake()
        {
            Instance = this as T;
        }
    }
}