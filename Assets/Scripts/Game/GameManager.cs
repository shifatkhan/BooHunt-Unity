using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = totalTime;
        difficultyChangeRate = totalTime / 3; // We will change difficulty every 1/3 of the way.
    }

    // Update is called once per frame
    void Update()
    {
        // Check if it's time to increase difficulty.
        if(Time.time > difficulty * difficultyChangeRate)
        {
            difficulty++;
        }

        timeRemaining -= Time.deltaTime;

        if(timeRemaining <= 0)
        {
            // TODO: Game over!
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        print($"Time remaining: {timeRemaining}");
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
