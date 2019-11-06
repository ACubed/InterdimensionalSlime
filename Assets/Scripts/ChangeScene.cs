using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public bool levelComplete = false;
    public CanvasGroup canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInParent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {

        if (levelComplete)
        {
            if (canvas.alpha < 1f)
            {
                canvas.alpha += 0.01f;
            }
            else
            {
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                Debug.Log(nextSceneIndex + " k");
                Debug.Log(SceneManager.sceneCountInBuildSettings + " 2");
                if (SceneManager.sceneCountInBuildSettings > nextSceneIndex) SceneManager.LoadScene(nextSceneIndex);
            }
            
        }

    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        levelComplete = true;
    } //end of method onced2d

}
