using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGameRed()
    {
        SceneManager.LoadScene("SampleScene 1");
    }
    public void StartGamePurple()
    {
        SceneManager.LoadScene("GreenScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
