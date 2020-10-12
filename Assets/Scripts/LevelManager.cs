using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    float FadeOutTime;
    float FadeInTime;

    [SerializeField]
    CanvasGroup BlackPanel;

    private static LevelManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        OptionsManager.alternativeExitPressed += OnPressExit;

        FadeOutTime = ScriptableConfigParser.instance.config.FadeOutTime;
        FadeInTime = ScriptableConfigParser.instance.config.FadeInTime;

        SceneManager.sceneLoaded += OnLevelFinishLoading;


    }

    //fadeIn event triggered by sceneLoad
    private void OnLevelFinishLoading(Scene scene, LoadSceneMode mode)
    {
        BlackPanel.alpha = 1;
        StartCoroutine(Fade(1, 0, FadeInTime, -1));
    }

    //logic for buttons connected to level management
    public void OnPressPlay() {
        AudioManager.instance.PlayButtonSound();
        StartCoroutine(Fade(0, 1, FadeOutTime, 1));
    }
    public void OnPressExit()
    {
        AudioManager.instance.PlayButtonSound();
        StartCoroutine(Fade(0, 1, FadeOutTime, 0));
    }
    public void OnPressQuit() {
        AudioManager.instance.PlayButtonSound();
        Application.Quit();
    }


    //works for both FadeIn and FadeOut, calls new level at the end of animation if needed
    private IEnumerator Fade(float startFade, float endFade, float time,  int sceneIndex)
    {
        float timePassed = Time.deltaTime;
        while (BlackPanel.alpha != endFade)
        {
            BlackPanel.alpha = Mathf.Lerp(startFade, endFade, timePassed/ time);
            timePassed += Time.deltaTime;
            yield return null;
        }
        if (sceneIndex < 0) {
            Debug.LogWarning("Unreachable variable read");
        }
        if (endFade == 1) {
            SceneManager.LoadScene(sceneIndex);
        }
        
    }
}
