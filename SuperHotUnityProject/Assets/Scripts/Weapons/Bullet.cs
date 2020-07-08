using Digital.AI;
using Digital.Core;
using UnityEngine;

namespace Digital.Weapons
{
    public class Bullet : MonoBehaviour
    {
        public enum Type
        {
            PLAYER, ENEMY
        }
        public Type type;

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
            if (collision.collider.CompareTag("Enemy") && type == Type.PLAYER)
            {
                collision.collider.GetComponent<Enemy>().Kill();
                Destroy(gameObject);
            }
            else if (collision.collider.CompareTag("Player") && type == Type.ENEMY)
            {
                GameManager.ins.Lose();
                Destroy(gameObject);
            }

        }
    }
}
