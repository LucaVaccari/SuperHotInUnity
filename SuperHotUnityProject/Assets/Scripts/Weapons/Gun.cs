using UnityEngine;

namespace Digital.Weapons
{
    public class Gun : MonoBehaviour, IWeapon
    {
        public MonoBehaviour MonoBehaviour => this;

        public bool Throwed { get; set; }

        public void Action()
        {
            //shoot
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

