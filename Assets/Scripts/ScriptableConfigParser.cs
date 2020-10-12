using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableConfigParser : MonoBehaviour
{
    #region AwakeAndSingleton
    public static ScriptableConfigParser instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        AudioManager.AudioManagerCreated += OnAudioManagerCreation;
    }
    #endregion

    public MenuUIDataScriptable config;

    public void OnAudioManagerCreation() {
        AddSound(config.music);
        AudioManager.instance.Music = config.music;
        AddSound(config.buttonSound);
        AudioManager.instance.Sounds.Add(config.buttonSound);
    }

    //to write names over characters heads
    public string GetActorName(int index)
    {
        return config.playerNames[index];
    }

    //Unwraps audio infomation
    private void AddSound(Sound item) {
        item.source = AudioManager.instance.gameObject.AddComponent<AudioSource>();
        item.source.clip = item.clip;

        item.source.outputAudioMixerGroup = item.mixer;

        item.source.volume = item.volume;
        item.source.loop = item.loop;
    }
}
