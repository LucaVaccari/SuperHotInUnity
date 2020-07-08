using Digital.Utils;
using UnityEngine;

namespace Digital.Core.Player
{
    public class WeaponHolder : Singleton<WeaponHolder>
    {
        [SerializeField] private Transform gunHolder;
        [SerializeField] private LayerMask weaponMask;
        [SerializeField] private float throwForce = 10;
        private IWeapon currentWeapon;

        private void Update()
        {
            if (currentWeapon != null)
            {
                currentWeapon.MonoBehaviour.transform.localPosition = Vector3.zero;
                currentWeapon.MonoBehaviour.transform.localRotation = Quaternion.identity;
            }

            if (Input.GetButtonDown("Action"))
            {
                if (currentWeapon == null)
                {
                    //punch
                }
                else
                {
                    //shoot
                    //possibly throw
                    currentWeapon.Action();
                }
            }
            if (Input.GetButtonDown("Throw"))
            {
                if (currentWeapon == null)
                    TryPickUp();
                else
                    Throw();
            }
        }
        public void Throw()
        {
            currentWeapon.MonoBehaviour.transform.parent = null;
            currentWeapon.MonoBehaviour.GetComponent<Rigidbody>().isKinematic = false;
            currentWeapon.MonoBehaviour.transform.position = GameManager.ins.cam.position + GameManager.ins.cam.forward;
            currentWeapon.MonoBehaviour.GetComponent<Rigidbody>().AddForce(GameManager.ins.cam.forward * throwForce * Time.unscaledDeltaTime, ForceMode.VelocityChange);
            currentWeapon.Throwed = true;
            currentWeapon = null;
        }

        private void TryPickUp()
        {
            if (currentWeapon == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(GameManager.ins.cam.position, GameManager.ins.cam.forward, out hit, 5, weaponMask))
                {
                    currentWeapon = hit.collider.GetComponent<IWeapon>();
                    currentWeapon.MonoBehaviour.transform.parent = gunHolder;
                    currentWeapon.MonoBehaviour.transform.localPosition = Vector3.zero;
                    currentWeapon.MonoBehaviour.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }
}
