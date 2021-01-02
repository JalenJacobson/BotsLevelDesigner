using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpTriggerCube : MonoBehaviour
{
    public GameObject Pump;
    PumpMove PumpMove_Script;
    
    public bool connected = false;
    public Vector3 connectPos;
    public GameObject touching = null;
    public Animator anim;
    public GameObject ActionPump;
    ActionPump Bubble_Script;
    public GameObject ActionPump2;
    ActionPump2 Bubble_Script2;
    public GameObject ActionLight;
    ActionPump Light_Script;
    public GameObject ActionCircles;
    ActionPump Circle_Script;
    public GameObject Activate1;
    Act1Script Act1Button_Script;
    public GameObject Cancel;
    CancelButton CancelButton_Script;
    public GameObject Cancel2;
    CancelButton CancelButton2_Script;
    public GameObject BlueWall;
    BlueWall BlueWall_Script;

    // Start is called before the first frame update
    void Start()
    {
        PumpMove_Script = Pump.GetComponent<PumpMove>();
        Bubble_Script = ActionPump.GetComponent<ActionPump>();
        Bubble_Script2 = ActionPump2.GetComponent<ActionPump2>();
        Light_Script = ActionLight.GetComponent<ActionPump>();
        Circle_Script = ActionCircles.GetComponent<ActionPump>();
        Act1Button_Script = Activate1.GetComponent<Act1Script>();
        CancelButton_Script = Cancel.GetComponent<CancelButton>();
        CancelButton2_Script = Cancel2.GetComponent<CancelButton>();
        BlueWall_Script = BlueWall.GetComponent<BlueWall>();
        anim = GetComponent<Animator>();
    }

   void OnTriggerEnter(Collider other)
     {
        if(other.name.Contains("Water"))
        {
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();
        }
        if(other.name.Contains("pump"))
        {
            Bubble_Script2.actionBubble2Start();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();
        }
     }

    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Water")){
             touching = other.gameObject;
  
        }
    }

     void OnTriggerExit(Collider other)
     {
        touching = null;
        if(other.name.Contains("Water"))
        {
            touching = null;
            Bubble_Script.actionBubbleStop();
            Light_Script.actionBubbleStop();
            Circle_Script.actionBubbleStop();
            BlueWall_Script.Stop();
            CancelButton_Script.CancelStop();
        }
        if(other.name.Contains("pump"))
        {
            touching = null;
            Bubble_Script.actionBubbleStop();
            Light_Script.actionBubbleStop();
            Circle_Script.actionBubbleStop();
            CancelButton_Script.CancelStop();
        }
     }

     void Update()
     {
         if(touching != null && Input.GetKeyDown("c"))
         {
             Connect();
         }
         if(touching != null && Input.GetKeyDown("d"))
         {
             Disconnect();
         }
         if(connected == true && Input.GetKeyDown("z"))
         {
             Activate();
         }
     }

         public void Reactivate()
     {
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();
     }
     public void Activate()
     {
             touching.SendMessage("Activate");
     }

     public void Connect()
     {
             connected = !connected;  
             PumpMove_Script.toggleFixPosition();
             CancelButton2_Script.CancelStart();
             Bubble_Script2.actionBubbleStop();     
     }
     
     public void Disconnect()
     {
             connected = false;  
             PumpMove_Script.toggleFixPosition();
             CancelButton2_Script.CancelStop();
             Light_Script.actionBubbleStop();
            Circle_Script.actionBubbleStop();     
     }
          public void WaterWall()
     {
        Bubble_Script.actionBubbleStop();
        CancelButton_Script.CancelStart();

     }
    
    public void WaterWallClose()
     {

        CancelButton_Script.CancelStop();
        BlueWall_Script.Stop();

     }
    
}
