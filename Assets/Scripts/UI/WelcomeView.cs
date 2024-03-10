using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeView : MonoBehaviour
{
    [SerializeField] private string gameplaySceneName = "GameplayScene";
    [SerializeField] private Button buttonPlay = null;
    [SerializeField] private AudioSource buttonAudioSource = null;
    [SerializeField] private AudioClip buttonAudioClip = null;

    private void OnEnable()
    {
        buttonPlay.onClick.AddListener(LoadWelcomeScreen);
    }

    private void OnDisable()
    {
        buttonPlay.onClick.RemoveAllListeners();
    }

    private void LoadWelcomeScreen()
    {
        buttonAudioSource.PlayOneShot(buttonAudioClip, 0.8f);

        float ms = Time.deltaTime;

        while (ms < 1.0f) ms += Time.deltaTime;

        SceneManager.LoadScene(gameplaySceneName);
    }
}
