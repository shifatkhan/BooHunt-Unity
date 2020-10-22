using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Difficulty")]
    [SerializeField]
    private float totalTime = 20f;
    private float timeRemaining = 20f;

    [SerializeField]
    private int difficulty = 1; // 1, 2, 3 = Easy, Medium, Hard
    private float difficultyChangeRate = 6.6f;

    public int score = 0;
    public bool candyAcquired = false; // This enables the Special game mode.
    private bool inSpecialMode = false;

    [Header("Special mode")]
    [SerializeField]
    private float specialModeDuration = 3f;
    public GameObject candy;
    public bool gameIsOver { get; private set; }
    [Header("UI")]
    public GameOver gameOver;

    public Text timeText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = totalTime;
        difficultyChangeRate = totalTime / 3; // We will change difficulty every 1/3 of the way.
        gameIsOver = false;

        if (timeText == null)
            timeText = GameObject.Find("TimeText").GetComponent<Text>();
        if (scoreText == null)
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsOver)
        {
            UpdateUI();

            // Check if it's time to increase difficulty.
            if (Time.time > difficulty * difficultyChangeRate)
            {
                difficulty++;
            }

            timeRemaining -= Time.deltaTime;

            if (Input.GetButtonDown("Submit") && candyAcquired)
            {
                StartSpecialMode();
            }

            if (timeRemaining <= 0)
            {
                gameIsOver = true;
                gameOver.StartGameOver(score);
            }
        }
    }

    private void StartSpecialMode()
    {
        inSpecialMode = true;
        candyAcquired = false;
        candy.GetComponent<Candy>().Die();
        StartCoroutine(StopSpecialMode());
    }

    IEnumerator StopSpecialMode()
    {
        yield return new WaitForSeconds(specialModeDuration);

        inSpecialMode = false;
    }

    private void UpdateUI()
    {
        timeText.text = timeRemaining.ToString("F2");
        scoreText.text = score.ToString();
    }

    public float GetTotalTime()
    {
        return totalTime;
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }

    public int GetDifficulty()
    {
        return difficulty;
    }

    public bool IsInSpecialMode()
    {
        return inSpecialMode;
    }
}
