using Digital.AI;
using Digital.Core.Managers;
using UnityEngine;

namespace Digital.Weapons
{
    public class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject throwParticles;
        [SerializeField] private AK.Wwise.Event shootSoundEvent;

        private float bullets = 5;

        public MonoBehaviour MonoBehaviour => this;

        public bool Throwed { get; set; }

        public void Action()
        {
            if(bullets > 0)
            {
                //play shoot animation

                shootSoundEvent.Post(AudioManager.ins.gameObject);

                //instantiate particles

                GameObject bulletIns = Instantiate(bulletPrefab, GameManager.ins.cam.position + GameManager.ins.cam.forward * 2, GameManager.ins.cam.rotation);
                bulletIns.GetComponent<Bullet>().direction = GameManager.ins.cam.forward;
                bullets--;
            }
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

