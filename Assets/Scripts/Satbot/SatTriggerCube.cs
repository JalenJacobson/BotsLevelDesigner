using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatTriggerCube : MonoBehaviour
{
    public GameObject SatBot;
    SatMove SatMove_Script;

    public bool triggerEntered = false;
    public GameObject touching = null;
    public string touchingToken;
    public bool connected = false;
    public Vector3 connectPos;
    public string token;

    public GameObject ActionDownload;
    DownloadBubbleScript Bubble_Script;
    public GameObject ActionLight;
    DownloadBubbleScript Light_Script;
    public GameObject ActionCircles;
    DownloadBubbleScript Circle_Script;
    public GameObject Activate1;
    Act1Script Act1Button_Script;
    public GameObject Cancel;
    CancelButton CancelButton_Script;
    
    // public GameObject TimerBarSat;
    // TimeBarSat TimerBarSat_Script;

    void Start(){
        SatMove_Script = SatBot.GetComponent<SatMove>();
        Bubble_Script = ActionDownload.GetComponent<DownloadBubbleScript>();
        Light_Script = ActionLight.GetComponent<DownloadBubbleScript>();
        Circle_Script = ActionCircles.GetComponent<DownloadBubbleScript>();
        Act1Button_Script = Activate1.GetComponent<Act1Script>();
        CancelButton_Script = Cancel.GetComponent<CancelButton>();
        // TimerBarSat_Script = TimerBarSat.GetComponent<TimeBarSat>();
    }

    void OnTriggerEnter(Collider other)
     {
        if(other.name.Contains("Sat")){
             
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();
             
        }
        if(other.name.Contains("Water"))
        {
            // TimerBarSat_Script.timerStart();
        }

    }

    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Sat")){
             touching = other.gameObject;
             if(other.name.Contains("Upload"))
             {
                 touchingToken = touching.GetComponent<Sat_Upload_1>().token;
             }
        }
        if(other.name.Contains("BlueWall"))
        {
            // TimerBarSat_Script.enterbluewall();
        }
    }

     void OnTriggerExit(Collider other)
     {
            touching = null;
            touchingToken = null;
                        if(other.name.Contains("Sat")){
            Bubble_Script.actionBubbleStop();
            Light_Script.actionBubbleStop();
            Circle_Script.actionBubbleStop();
        }
        if(other.name.Contains("Water"))
        {
            // TimerBarSat_Script.timerStop();
        }
        if(other.name.Contains("BlueWall"))
        {
            // TimerBarSat_Script.exitbluewall();
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

         if(touching != null && connected == true && Input.GetKeyDown("z"))
        {
            if(touching.name.Contains("Download"))
            {
                DownloadToken();
            }
                
        }

         if(token == touchingToken && connected == true && Input.GetKeyDown("z"))
         {
             Activate();
         }
     }

    void DownloadToken()
    {
        token = touching.GetComponent<Sat_Download_1>().token;
                print("download");
    }

    public void Activate()
     {
        if(touching.name.Contains("Download"))
        {
            DownloadToken();
        }
        else if(touching.name.Contains("Upload"))
        {
            if(token == touchingToken)
            {
                touching.SendMessage("Activate");
            }
            else{print("Need Token");}
        } 
             
     }

     public void Connect()
     {
             connected = !connected;  
             SatMove_Script.toggleFixPosition();
            Bubble_Script.actionBubbleStop();
            Act1Button_Script.activate1();
            CancelButton_Script.CancelStart();     
     }
     
     public void Disconnect()
     {
             connected = false;  
             SatMove_Script.toggleFixPosition();
            Light_Script.actionBubbleStop();
            Circle_Script.actionBubbleStop();
            Act1Button_Script.activate1Stop();
            CancelButton_Script.CancelStop();      
     }
}
