using UnityEngine;
using UnityEngine.Audio;

//blueprint for sound-file injecting via Inspector
[System.Serializable]
public class Sound {
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    public AudioMixerGroup mixer;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
