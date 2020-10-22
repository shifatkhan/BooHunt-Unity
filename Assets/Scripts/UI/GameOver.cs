using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private int finalScore;
    public Text finalScoreText;
    private Animator animator;

    public GameObject tryAgainBtn;
    public GameObject mainMenuBtn;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (finalScoreText == null)
            finalScoreText = GameObject.Find("FinalScoreText").GetComponent<Text>();

        tryAgainBtn.gameObject.SetActive(false);
        mainMenuBtn.gameObject.SetActive(false);
    }

    public void StartGameOver(int score)
    {
        tryAgainBtn.gameObject.SetActive(true);
        mainMenuBtn.gameObject.SetActive(true);

        finalScore = score;
        finalScoreText.text = score.ToString();
        animator.SetTrigger("Game Over");

        // Show OS cursor.
        Cursor.visible = true;
    }

    public void TryAgainClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenuClicked()
    {

    }
}
