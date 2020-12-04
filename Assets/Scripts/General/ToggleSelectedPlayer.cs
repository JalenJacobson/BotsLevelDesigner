using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSelectedPlayer : MonoBehaviour
{
    public GameObject Gears;
    public GameObject Luz;
    public GameObject Brute;
    public GameObject Pump;
    public GameObject Sat;
    public GameObject Main_Camera;
    
    GearMove gearMove_script;
    LuzMove luzMove_script;
    BruteMove bruteMove_script;
    PumpMove pumpMove_script;
    SatMove satMove_script;
    
    GearbotLevelInteraction gearbotLevelInteraction_script;
    // LuzbotLevelInteraction luzbotLevelInteraction_script;
    BruteBotLevelInteraction bruteBotLevelInteraction_script;
    // PumpBotBotLevelInteraction pumpBotLevelInteraction_script;
    // SatBotBotLevelInteraction satBotLevelInteraction_script;
    
    CameraFollow cameraFollow_script;

    // Start is called before the first frame update
    void Start()
    {
        gearMove_script = Gears.GetComponent<GearMove>();  
        luzMove_script = Luz.GetComponent<LuzMove>();
        bruteMove_script = Brute.GetComponent<BruteMove>();
        pumpMove_script = Pump.GetComponent<PumpMove>();
        satMove_script = Sat.GetComponent<SatMove>();
        
        gearbotLevelInteraction_script = Gears.GetComponent<GearbotLevelInteraction>();  
        bruteBotLevelInteraction_script = Brute.GetComponent<BruteBotLevelInteraction>();
        // pumpBotLevelInteraction_script = Pump.GetComponent<PumpBotLevelInteraction>();
        // satBotLevelInteraction_script = Sat.GetComponent<SatBotLevelInteraction>();

        cameraFollow_script = Main_Camera.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    public void Toggle()
    {
        // var playerScripts = new Component[] {gearMove_script, luzMove_script, bruteMove_script, pumpMove_script, satMove_script};

        {
            //gear to luz
            if(gearMove_script.toggleSelected == true){
                gearMove_script.toggleSelectedState();
                luzMove_script.toggleSelectedState();
                gearbotLevelInteraction_script.toggleSelectedState();
                cameraFollow_script.togglePlayerFollow(Luz);
            }
            //luz to brute
            else if(luzMove_script.toggleSelected == true){
                bruteMove_script.toggleSelectedState();
                luzMove_script.toggleSelectedState();
                bruteBotLevelInteraction_script.toggleSelectedState();
                cameraFollow_script.togglePlayerFollow(Brute);
            }
            //brute to pump
            else if(bruteMove_script.toggleSelected == true){
                bruteMove_script.toggleSelectedState();
                pumpMove_script.toggleSelectedState();
                bruteBotLevelInteraction_script.toggleSelectedState();
                // pumpLevelInteraction_script.toggleSelectedState();
                cameraFollow_script.togglePlayerFollow(Pump);
            }
            //pump to sat
            else if(pumpMove_script.toggleSelected == true){
                pumpMove_script.toggleSelectedState();
                satMove_script.toggleSelectedState();
                // pumpLevelInteraction_script.toggleSelectedState();
                // satLevelInteraction_script.toggleSelectedState();
                cameraFollow_script.togglePlayerFollow(Sat);
            }
            //sat to gears
            else if(satMove_script.toggleSelected == true){
                satMove_script.toggleSelectedState();
                gearMove_script.toggleSelectedState();
                // satLevelInteraction_script.toggleSelectedState();
                gearbotLevelInteraction_script.toggleSelectedState();
                cameraFollow_script.togglePlayerFollow(Gears);
            }
        }
        
    }
}
