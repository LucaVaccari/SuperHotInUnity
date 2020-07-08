using Digital.Core.Player;
using Digital.Utils;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Digital.Core
{
    public class GameManager : Singleton<GameManager>
    {
        public Transform cam;
        public Transform player;

        public void Lose()
        {
            Debug.Log("Lose");
            Time.timeScale = 0;
            player.GetComponent<WeaponHolder>().enabled = false;
            player.GetComponent<FirstPersonController>().enabled = false;
        }
    }
}
