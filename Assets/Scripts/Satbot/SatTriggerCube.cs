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

    void Start(){
        SatMove_Script = SatBot.GetComponent<SatMove>();
    }

    void OnTriggerEnter(Collider other)
     {

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
