using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Select", LoadSceneMode.Single);
    }

    public void Help()
    {
        SceneManager.LoadScene("Help", LoadSceneMode.Single);
    }
}
