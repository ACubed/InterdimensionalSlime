using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public static void Quit()
    {
        Application.Quit();
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Select", LoadSceneMode.Single);
    }

    public void Continue()
    {
        Debug.Log("continue the game from save");
    }
}
