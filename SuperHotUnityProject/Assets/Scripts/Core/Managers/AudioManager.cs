using Digital.Utils;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AK.Wwise.RTPC timescale;
    [SerializeField] private AK.Wwise.Event mainMusicEvent, stopEveryThing;

    private void Start()
    {
        stopEveryThing.Post(gameObject);
        mainMusicEvent.Post(gameObject);
    }

    private void Update()
    {
        timescale.SetGlobalValue(Time.timeScale);
    }

    private void OnDestroy()
    {
        stopEveryThing.Post(gameObject);
    }
    private void OnApplicationQuit()
    {
        stopEveryThing.Post(gameObject);
    }
    private void OnDisable()
    {
        stopEveryThing.Post(gameObject);
    }
}
