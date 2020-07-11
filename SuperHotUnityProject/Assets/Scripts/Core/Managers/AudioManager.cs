using Digital.Utils;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AK.Wwise.RTPC timescale;

    void Update()
    {
        timescale.SetGlobalValue(Time.timeScale);
    }
}
