using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Selector : MonoBehaviour
{
    public GameObject Level_Manager;
    Level_Manager LevelManager_script;
    public int newScene;
    
    public Transform Selector_Position;

    void Start()
    {
        LevelManager_script = Level_Manager.GetComponent<Level_Manager>();
        Selector_Position = GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider other)
    {
        print(Selector_Position.position);
        LevelManager_script.setSceneToGoTo(newScene);
        PlayerPrefs.SetInt("currentLevel", newScene);
        other.transform.position = Selector_Position.position;
    }

    void Update()
    {
    }
    
    void OnTriggerExit(Collider other)
    {
        LevelManager_script.setSceneToGoTo(1);
        PlayerPrefs.SetInt("currentLevel", 1);
    }

   
}
