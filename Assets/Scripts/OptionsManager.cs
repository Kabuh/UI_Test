using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsManager : MonoBehaviour
{
    public delegate void OptionsEvent();
    public static OptionsEvent alternativeExitPressed;

    #region Variables
    bool musicActive = true;
    bool soundsActive = true;

    Vector3 startPos;
    Vector3 destination;

    float rollUpSpeed;
    float rollDownSpeed;

    [SerializeField]
    Image myPanel;

    IEnumerator movement;

    [SerializeField]
    AudioMixer audioMixer;
    AudioManager audioManager;

    private void Awake()
    {
        startPos = transform.position;
        destination = myPanel.transform.position;
        destination.z = startPos.z;

        rollUpSpeed = ScriptableConfigParser.instance.config.MenuPopUpSpeed;
        rollDownSpeed = ScriptableConfigParser.instance.config.MenuHideSpeed;
    }
    #endregion

    //section about Option menu pop-up movement
    #region OptionsMovement
    public void Init()
    {
        audioManager = AudioManager.instance;
        audioManager?.PlayButtonSound();
        GOSwitch();
        movement = MoveTo(startPos, destination, rollUpSpeed, false);
        StartCoroutine(movement);
    }

    public void QuitMenu()
    {
        audioManager?.PlayButtonSound();
        StopCoroutine(movement);
        movement = MoveTo(destination, startPos, rollDownSpeed, true);
        StartCoroutine(movement);
    }

    private IEnumerator MoveTo(Vector3 start, Vector3 end, float speed, bool switchActive)
    {
        while (transform.position != end)
        {
            transform.position = Vector3.MoveTowards(transform.position, end, speed);
            yield return new WaitForFixedUpdate();
        }
        if (switchActive)
        {
            GOSwitch();
        }
    }

    private void GOSwitch()
    {
        if (myPanel.gameObject.activeSelf)
            myPanel.gameObject.SetActive(false);
        else
            myPanel.gameObject.SetActive(true);
    }
    #endregion

    //section about bringing changes to Audio manager
    #region SoundTweaks

    //per slider call
    public void OnVolumeChange(float value)
    {
        audioManager.PlayButtonSound();
        float masterVolume = -80 + value * 4;
        audioMixer.SetFloat("Volume", masterVolume);
    }

    //on-off switch
    public void OnMusicSwitch()
    {
        audioManager?.PlayButtonSound();
        if (musicActive)
        {
            audioManager?.SetMusicVolume(-80);
            musicActive = false;
        }
        else
        {
            audioManager?.SetMusicVolume(0);
            musicActive = true;
        }

    }

    //on-off switch
    public void OnSoundSwitch()
    {
        if (soundsActive)
        {
            audioManager?.SetSoundsVolume(-80);
            soundsActive = false;
        }
        else
        {
            audioManager?.SetSoundsVolume(0);
            soundsActive = true;
            audioManager?.PlayButtonSound();
        }
    }
    #endregion

    #region AlternativeExitButton#
    public void OnExitPress() {
        alternativeExitPressed();
    }
    #endregion
}
