using UnityEngine;

namespace Digital.Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] float force;

        Rigidbody rb;

        [HideInInspector] public Vector3 direction;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();

            rb.AddForce(direction * force * Time.fixedUnscaledDeltaTime, ForceMode.Force);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}
