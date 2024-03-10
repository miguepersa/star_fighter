using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirectorController : MonoBehaviour
{
    [SerializeField] private PlayerController player = null;
    [SerializeField] private AsteroidGenerator asteroidGenerator = null;
    [SerializeField] private GameplayView gameplayView = null;
    [SerializeField] private int scoreWin = 2;

    [Space(30)]
    [SerializeField] private string welcomeScreenName = "WelcomeScene";

    private int score;

    private void OnEnable()
    {
        asteroidGenerator.OnAsteroidDestroyed += AsteroidDestroyedHandler;
    }

    private void OnDisable()
    {
        asteroidGenerator.OnAsteroidDestroyed -= AsteroidDestroyedHandler;
    }

    private void Start()
    {
        InitGame();
    }

    private void InitGame()
    {
        score = 0;
        gameplayView.SetScore(score);
    }

    private void AsteroidDestroyedHandler(int points)
    {
        score += points;
        gameplayView.SetScore(score);

        if (score >= scoreWin) LoadWelcomeScreen();
    }

    private void LoadWelcomeScreen()
    {
        SceneManager.LoadScene(welcomeScreenName);
    }
}
