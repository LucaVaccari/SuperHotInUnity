using Digital.Core.Player;
using UnityEngine;

namespace Digital.Weapons
{
    public class WeaponObject : MonoBehaviour, IWeapon
    {
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
                Destroy(gameObject);
            }
        }
    }
}

