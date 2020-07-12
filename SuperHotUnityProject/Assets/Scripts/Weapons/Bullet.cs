using Digital.AI;
using Digital.Core.Managers;
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

        [SerializeField] private float force;
        private Rigidbody rb;

        [HideInInspector] public Vector3 direction;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();

            rb.AddForce(direction * force * Time.fixedUnscaledDeltaTime * 100, ForceMode.Force);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Enemy") && type == Type.PLAYER)
            {
                collision.collider.GetComponent<Enemy>().Kill();
            }
            else if (collision.collider.CompareTag("Player") && type == Type.ENEMY)
            {
                GameManager.ins.Lose();
            }

            if (!(collision.collider.CompareTag("Enemy") && type == Type.ENEMY))
                Destroy(gameObject);

        }
    }
}
