using Digital.Core;
using UnityEngine;

namespace Digital.Weapons
{
    public class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] GameObject bulletPrefab;

        public MonoBehaviour MonoBehaviour => this;

        public bool Throwed { get; set; }

        public void Action()
        {
            //play shoot animation
            //play shoot sound
            //instantiate particles
            GameObject bulletIns = Instantiate(bulletPrefab, GameManager.ins.cam.position, GameManager.ins.cam.rotation);
            bulletIns.GetComponent<Bullet>().direction = GameManager.ins.cam.forward;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (Throwed)
            {
                Destroy(gameObject);
            }
        }
    }
}

