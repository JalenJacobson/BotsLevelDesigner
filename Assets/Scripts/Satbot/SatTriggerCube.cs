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

    void Start(){
        SatMove_Script = SatBot.GetComponent<SatMove>();
        Bubble_Script = ActionDownload.GetComponent<DownloadBubbleScript>();
        Light_Script = ActionLight.GetComponent<DownloadBubbleScript>();
        Circle_Script = ActionCircles.GetComponent<DownloadBubbleScript>();
    }

    void OnTriggerEnter(Collider other)
     {
        if(other.name.Contains("Sat")){
             
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();
             
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

    void Activate()
     {
             touching.SendMessage("Activate");
     }

     void Connect()
     {
             connected = true;  
             SatMove_Script.toggleFixPosition();     
     }
     
     void Disconnect()
     {
             connected = false;  
             SatMove_Script.toggleFixPosition();     
     }
}
