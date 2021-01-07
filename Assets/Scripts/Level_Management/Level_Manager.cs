using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    public int sceneToGoTo;
    void Start()
    {
        sceneToGoTo = 1;
    }

    void Update()
    {
        if(sceneToGoTo != 1 && Input.GetKeyDown("q"))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {

        SceneManager.LoadScene(sceneToGoTo);
        // sceneToGoTo = 1;
    }

    public void setSceneToGoTo(int nextScene)
    {
        sceneToGoTo = nextScene;
    }
}
