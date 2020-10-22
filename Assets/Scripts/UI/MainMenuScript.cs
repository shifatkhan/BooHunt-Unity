using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void PlayClicked()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitClicked()
    {
        Application.Quit();
    }
}
