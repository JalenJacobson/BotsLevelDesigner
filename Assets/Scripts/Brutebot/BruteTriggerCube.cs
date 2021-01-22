using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteTriggerCube : MonoBehaviour
{
    public Animator anim;
    public bool triggerEntered = false;
    public GameObject touching = null;
    public bool canLift = false;
    public Vector3 liftPos;
    public bool lifting;

    public GameObject ActionBrute;
    BruteBubbleScript Bubble_Script;
    public GameObject ActionLight;
    BruteBubbleScript Light_Script;
    public GameObject ActionCircles;
    BruteBubbleScript Circle_Script;
    
    public GameObject Cancel;
    CancelButton CancelButton_Script;
    public GameObject Brute;
    MoveBruteW AnimArms_Script;

    public float force; 
    public float boxWeight;
    public float forceIncreaser = 1f;
    public float forceReducer = .5f;
    public float forceReducerConstant;
    // public GameObject TimerBarBrute;
    // TimeBarBrute TimerBarBrute_Script;

    void Start()
    {
        liftPos = new Vector3(0.0f, -0.5f, -1.0f);
        anim = GetComponent<Animator>();
        Bubble_Script = ActionBrute.GetComponent<BruteBubbleScript>();
        Light_Script = ActionLight.GetComponent<BruteBubbleScript>();
        Circle_Script = ActionCircles.GetComponent<BruteBubbleScript>();
        CancelButton_Script = Cancel.GetComponent<CancelButton>();
        AnimArms_Script = Brute.GetComponent<MoveBruteW>();
        force = 0f;
        // TimerBarBrute_Script = TimerBarBrute.GetComponent<TimeBarBrute>();
    }

    void OnTriggerEnter(Collider other)
     {
          canLift = true;
     }

    void OnTriggerStay(Collider other)
    {
        var characterName = other.name;
        if(characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump")
        {
            if(touching == null)
            {
                touching = other.gameObject; 
            }
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();   
        }
        if(characterName.Contains("Box"))
        {
            if(touching == null)
            {
                touching = other.gameObject; 
            }
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart(); 
            boxWeight = touching.GetComponent<Box>().weight;
            
            if(force > boxWeight)
            {
                touching.SendMessage("unfreeze");
            }
            else if(force < boxWeight)
            {
                touching.SendMessage("freeze");
            }
        }
        
    }

     void OnTriggerExit(Collider other)
     { 
        var characterName = other.name;    
        if(characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" || characterName.Contains("Box"))
        {   
            if(lifting == false)
            {
                canLift = false;
                touching = null;
            }
        Bubble_Script.actionBubbleStop();
        Light_Script.actionBubbleStop();
        Circle_Script.actionBubbleStop();
        // lifting = false;
        }
        if(characterName.Contains("Box"))
        {
            boxWeight = 0f;
            // force = 0f;
            forceIncreaser = 1.25f;
            forceReducer = .2f;
        }
     }

     void Update()
     {   
        if(lifting == true)
        {
            touching.transform.position = transform.TransformPoint(liftPos);
            CancelButton_Script.CancelStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();
            Bubble_Script.actionBubbleStop();
            AnimArms_Script.Lift(); 
        }
        if(force > 0)
        {
            force = force - forceReducer * Time.deltaTime;
        }
        
        if(force > 30f)
        {
            forceReducerConstant = 3f;
        }
        else if(force > 25f)
        {
            forceReducerConstant = 2.75f;
        }
        else if(force > 15f)
        {
            forceReducerConstant = 2.55f;
        }
        else{forceReducerConstant = 2.5f;}

        if(forceIncreaser < 1.25)
        {
            forceIncreaser = forceIncreaser + .1f * Time.deltaTime;
        }
        if(forceReducer > .5)
        {
            forceReducer = forceReducer - .1f * Time.deltaTime;
        }
        
     }

     public void drop()
     {
        Light_Script.actionBubbleStop();
        Circle_Script.actionBubbleStop();
        CancelButton_Script.CancelStop();
        lifting = !lifting;
        AnimArms_Script.Drop();  
     }
    
    public void lift() 
    {
        if(touching.name == "IdleLuz" || touching.name == "Gears" || touching.name == "SatBot" || touching.name == "Pump")
        {
            lifting = !lifting;
        }
        else if(touching.name.Contains("Box"))
        {
            increaseForce();
        }
    }

    public void increaseForce()
    {
        force = force + (1f * forceIncreaser);
        if(forceIncreaser > .5)
        {
            forceIncreaser = forceIncreaser - .05f;
            
        }
        if(forceReducer < forceReducerConstant)
        {
            forceReducer = forceReducer + .1f;
        }
        
    }
}


// I can do about 5 clicks in a second. if I want it to reach a 0 point I need the amount of increase of 5 clicks to be about the same as the amout of decrease of 1 second.
//so if, at the 0 point I am getting .5 per click for 2.5 increase then I need the decrease to be 2.5 in one second. 