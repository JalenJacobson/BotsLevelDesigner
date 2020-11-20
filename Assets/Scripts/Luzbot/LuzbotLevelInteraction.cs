using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzbotLevelInteraction : MonoBehaviour
{

    public bool toggleSelected = false;
    public bool canInteract = false;
    public bool canInteract2 = false;
    
    public GameObject level_luz_powerconnection_1;
    PowerConnection powerConnectionTrigger_script1;
    
    public GameObject level_luz_powerconnection_2;
    PowerConnection_2 powerConnectionTrigger_script2;

    
    // Start is called before the first frame update
    void Start()
    {
        powerConnectionTrigger_script1 = level_luz_powerconnection_1.GetComponent<PowerConnection>();
        powerConnectionTrigger_script2 = level_luz_powerconnection_2.GetComponent<PowerConnection_2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(toggleSelected == true && canInteract == true){
            if (Input.GetKeyDown("z"))
                {
                    // powerConnectionTrigger_script1.changePowerConnectionPos(1);
                    
                }
        }
        else if(toggleSelected == true && canInteract2 == true)
        {
            if(Input.GetKeyDown("z"))
            {
                powerConnectionTrigger_script2.changePowerConnectionPos(1);
            }
            
        }
        
        
    }

    public void toggleSelectedState (){
        toggleSelected = !toggleSelected;
    }

    public void canInteractEnter(){
        canInteract = true;
    }
    public void canInteractExit(){
        canInteract = false;
    }
    public void canInteractEnter2(){
        canInteract2 = true;
    }
    public void canInteractExit2(){
        canInteract2 = false;
    }
}
