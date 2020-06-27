using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Help : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        Debug.Log("clicked");
    }
}
