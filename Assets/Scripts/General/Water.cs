using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject TimerBarGear;
    TimeBarGear TimerBar_Script;

    void Start()
    {
    TimerBar_Script = TimerBarGear.GetComponent<TimeBarGear>();
    }

    void OnTriggerEnter(Collider other)
    {
    }

    void OnTriggerStay(Collider other)
    {
       var characterName = other.name;
        print(characterName);
        if(characterName == "Brute" || characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot")
        {
            other.gameObject.SendMessage("waterEnter"); 
            TimerBar_Script.timerStart();  
        }
    }

     void OnTriggerExit(Collider other)
     {
        var characterName = other.name;
        print(characterName);
        if(characterName == "Brute" || characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot")
        {
            other.gameObject.SendMessage("resetBreath");
            TimerBar_Script.timerStop();
        }
     }
}
