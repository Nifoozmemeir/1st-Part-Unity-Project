using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuITS : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("ShootEmUpInTheSpace");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
