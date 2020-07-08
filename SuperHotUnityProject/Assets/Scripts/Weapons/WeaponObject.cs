using Digital.AI;
using Digital.Core.Player;
using UnityEngine;

namespace Digital.Weapons
{
    public class WeaponObject : MonoBehaviour, IWeapon
    {
        [SerializeField] GameObject throwParticles;

        public MonoBehaviour MonoBehaviour => this;
        public bool Throwed { get; set; }

        public void Action()
        {
            WeaponHolder.ins.Throw();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (Throwed)
            {
                if (collision.collider.CompareTag("Enemy"))
                {
                    collision.collider.GetComponent<Enemy>().Kill();
                }
                Instantiate(throwParticles, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}

