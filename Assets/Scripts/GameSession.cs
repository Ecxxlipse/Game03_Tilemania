using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] public int score = 0;
    [SerializeField] float restartDelay = 1f;
    [SerializeField] float powerupDuration = 0f;
    [SerializeField] PowerUpHandler pwrUp;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
//    [SerializeField] TextMeshProUGUI powerupText;

    bool pwrUpCheck;

    void Awake()
    {
        int numberGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
//        pwrUp = GetComponent<PowerUpHandler>();
//        pwrUpCheck = pwrUp.hasJumpBoost;
//        powerupText.text = powerupDuration.ToString();

    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddtoScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void PwrUpDuration()
    {
        if (pwrUpCheck == true)
        {
            powerupDuration = 5f;
            Debug.Log("powerup Check");
        }
    }

    void TakeLife()
    {
        playerLives--;
        StartCoroutine(RestartAfterDelay());
        livesText.text = playerLives.ToString();
    }

    void ResetGameSession()
    {
        FindFirstObjectByType<ScenePersist>().ResetScenePersist();
        StartCoroutine(RestartGameAfterDelay());
    }



    IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(restartDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    IEnumerator RestartGameAfterDelay()
    {
        yield return new WaitForSeconds(restartDelay);
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }



}
