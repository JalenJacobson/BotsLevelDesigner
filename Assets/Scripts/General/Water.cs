using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject TimerBarGear;
    TimeBarGear TimerBar_Script;
    public GameObject TimerBarBrute;
    TimeBarBrute TimerBarBrute_Script;
    public GameObject TimerBarSat;
    TimeBarSat TimerBarSat_Script;

    void Start()
    {
    TimerBar_Script = TimerBarGear.GetComponent<TimeBarGear>();
    TimerBarBrute_Script = TimerBarBrute.GetComponent<TimeBarBrute>();
    TimerBarSat_Script = TimerBarSat.GetComponent<TimeBarSat>();
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
            TimerBarBrute_Script.timerStart();
            TimerBarSat_Script.timerStart();  
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
            TimerBarBrute_Script.timerStop();
            TimerBarSat_Script.timerStop();
        }
     }
}
