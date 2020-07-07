using UnityEngine;

namespace Digital
{
    namespace Utils
    {
        public class Singleton<T> : MonoBehaviour where T : Singleton<T>
        {
            public static T ins;

            protected virtual void Awake()
            {
                if (ins == null)
                    ins = (T)this;
                else
                    Destroy(gameObject);
            }
        }
    }
}