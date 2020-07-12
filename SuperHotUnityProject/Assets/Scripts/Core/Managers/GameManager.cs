using Digital.Core.Player;
using Digital.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

namespace Digital.Core.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public Transform cam;
        public Transform player;
        private bool lost = false;

        private void Update()
        {
            if (lost)
            {
                if (Input.anyKeyDown)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }

        public void Lose()
        {
            Time.timeScale = .01f;
            player.GetComponent<WeaponHolder>().enabled = false;
            player.GetComponent<FirstPersonController>().enabled = false;
            lost = true;
        }
        public void Win()
        {

        }
    }
}
