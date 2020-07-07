using UnityEngine;

namespace Digital
{
    namespace Core
    {
        namespace Player
        {
            public class WeaponHolder : MonoBehaviour
            {
                [SerializeField] private Transform gunHolder;
                [SerializeField] LayerMask weaponMask;

                IWeapon currentWeapon;

                private void Update()
                {
                    if(currentWeapon != null)
                    {
                        currentWeapon.MonoBehaviour.transform.localPosition = Vector3.zero;
                        currentWeapon.MonoBehaviour.transform.localRotation = Quaternion.identity;
                    }

                    if (Input.GetButtonDown("Action"))
                    {
                        //shoot
                        //punch
                        //possibly throw
                    }
                    if (Input.GetButtonDown("Throw"))
                    {
                        if (currentWeapon == null)
                            TryPickUp();
                        else
                            Throw();
                    }
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
                private void Throw()
                {
                    currentWeapon.MonoBehaviour.transform.parent = null;
                    currentWeapon.MonoBehaviour.GetComponent<Rigidbody>().isKinematic = false;
                    currentWeapon = null;
                }
            }
        }
    }
}
