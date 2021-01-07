using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Selector : MonoBehaviour
{
    public GameObject Level_Manager;
    Level_Manager LevelManager_script;
    public int newScene;

    void Start()
    {
        LevelManager_script = Level_Manager.GetComponent<Level_Manager>();
    }

    void OnTriggerEnter(Collider other)
    {
       
        LevelManager_script.setSceneToGoTo(newScene);
        // other.transform.position = levelBeaconPosition;
        // other.transform.position = levelBeaconPosition;

    }
    
    void OnTriggerExit(Collider other)
    {
        LevelManager_script.setSceneToGoTo(1);
    }
}
