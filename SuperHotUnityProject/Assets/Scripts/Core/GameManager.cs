using Digital.Utils;
using UnityEngine;

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
        }
    }
}
