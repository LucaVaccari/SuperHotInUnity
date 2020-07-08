using Digital.AI;
using Digital.Core;
using UnityEngine;

namespace Digital.Weapons
{
    public class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] GameObject throwParticles;

        public MonoBehaviour MonoBehaviour => this;

        public bool Throwed { get; set; }

        public void Action()
        {
            //play shoot animation
            //play shoot sound
            //instantiate particles
            GameObject bulletIns = Instantiate(bulletPrefab, GameManager.ins.cam.position + GameManager.ins.cam.forward * 2, GameManager.ins.cam.rotation);
            bulletIns.GetComponent<Bullet>().direction = GameManager.ins.cam.forward;
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

