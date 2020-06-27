using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void LevelThree()
    {
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
    }

    public void LevelFour()
    {
        SceneManager.LoadScene("Level4", LoadSceneMode.Single);
    }

    public void LevelFive()
    {
        SceneManager.LoadScene("Level5", LoadSceneMode.Single);
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}
