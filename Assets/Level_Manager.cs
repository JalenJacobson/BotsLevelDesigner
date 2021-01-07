using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
    
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }
}
