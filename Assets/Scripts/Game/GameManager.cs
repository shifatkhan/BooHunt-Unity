using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float totalTime = 20f;
    private float timeRemaining = 20f;

    [SerializeField]
    private int difficulty = 1; // 1, 2, 3 = Easy, Medium, Hard
    private float difficultyChangeRate = 6.6f;

    public int score = 0;
    private bool inSpecialMode = false;

    public Text timeText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = totalTime;
        difficultyChangeRate = totalTime / 3; // We will change difficulty every 1/3 of the way.

        if (timeText == null)
            timeText = GameObject.Find("TimeText").GetComponent<Text>();
        if (scoreText == null)
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();

        // Check if it's time to increase difficulty.
        if (Time.time > difficulty * difficultyChangeRate)
        {
            difficulty++;
        }

        timeRemaining -= Time.deltaTime;

        if(timeRemaining <= 0)
        {
            // TODO: Game over!
        }
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
