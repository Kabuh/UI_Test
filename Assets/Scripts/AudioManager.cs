using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager instance;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public delegate void AudioManagerEvent();
    public static AudioManagerEvent AudioManagerCreated;

    public Sound Music;
    public List<Sound> Sounds;

    private void Start()
    {
        AudioManagerCreated();
        Music.source.Play();
    }

    //self-explanatory
    public void PlayButtonSound() {
        Sounds[0].source.Play();
    }
    public void SetMusicVolume(float value) {
        Music.source.outputAudioMixerGroup.audioMixer.SetFloat("musicVolume", value);
    }
    public void SetSoundsVolume(float value) {
        Sounds[0].source.outputAudioMixerGroup.audioMixer.SetFloat("soundVolume", value);
    }
}
