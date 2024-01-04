using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource music;

    public void SetMusicEnable(bool value)
    {
        music.enabled = value;
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}
