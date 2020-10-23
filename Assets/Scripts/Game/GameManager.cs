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

    private int difficulty = 1; // 1, 2, 3 = Easy, Medium, Hard
    private float difficultyTime = 0.0f;
    private float difficultyChangeRate = 6.6f;

    public int score = 0;
    public bool candyAcquired = false; // This enables the Special game mode.
    private bool inSpecialMode = false;

    [Header("Special mode")]
    [SerializeField]
    private float specialModeDuration = 3f;
    public GameObject candy;
    public bool gameIsOver { get; private set; }
    public GameObject[] vfx;

    private Coroutine specialCo;

    [Header("UI")]
    public GameOver gameOver;

    public Text timeText;
    public Text scoreText;
    public SpecialModeSlider slider;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = totalTime;
        difficultyChangeRate = totalTime / 3; // We will change difficulty every 1/3 of the way.
        gameIsOver = false;
        difficultyTime = Time.time + difficultyChangeRate;
        MusicPlayer.SetVolume(MusicPlayer.initialVolume);

        // Remove side vfx for Frenzy mode.
        foreach (GameObject go in vfx)
        {
            go.SetActive(false);
        }

        if (timeText == null)
            timeText = GameObject.Find("TimeText").GetComponent<Text>();
        if (scoreText == null)
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        if (slider == null)
            slider = GameObject.Find("SliderContainer").GetComponent<SpecialModeSlider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsOver)
        {
            UpdateUI();

            // Check if it's time to increase difficulty.
            if (Time.time > difficultyTime)
            {
                difficulty++;
                difficultyTime += difficultyChangeRate;
            }

            timeRemaining -= Time.deltaTime;

            if (!PauseScript.isPaused && Input.GetButtonDown("Submit") && candyAcquired)
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
        // Allow to reset Special mode if it's activated again
        // while already in special mode.
        if(specialCo != null)
        {
            StopCoroutine(specialCo);
        }

        inSpecialMode = true;
        candyAcquired = false;
        candy.GetComponent<Candy>().Die();
        slider.StartSlider();
        CandySound.PlayCandyUse();
        MusicPlayer.SetSpeed(1.2f);
        foreach (GameObject go in vfx)
        {
            go.SetActive(true);
        }
        specialCo = StartCoroutine(StopSpecialMode());
    }

    IEnumerator StopSpecialMode()
    {
        yield return new WaitForSeconds(specialModeDuration);

        foreach (GameObject go in vfx)
        {
            go.SetActive(false);
        }
        inSpecialMode = false;
        MusicPlayer.SetSpeed(1);
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

    public float GetSpecialModeDuration()
    {
        return specialModeDuration;
    }
}
