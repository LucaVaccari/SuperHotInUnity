using UnityEngine;

namespace Digital.Utils
{
    public class DestroyAfter : MonoBehaviour
    {
        [SerializeField] private float timeToDestroy = 2f;

        private void Start()
        {
            Destroy(gameObject, timeToDestroy);
        }
    }
}