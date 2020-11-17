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
    
    GearMove gearMove_script;
    LuzMove luzMove_script;
    BruteMove bruteMove_script;
    PumpMove pumpMove_script;
    SatMove satMove_script;
    
    GearbotLevelInteraction gearbotLevelInteraction_script;
    LuzbotLevelInteraction luzbotLevelInteraction_script;
    BruteBotLevelInteraction bruteBotLevelInteraction_script;
    // PumpBotBotLevelInteraction pumpBotLevelInteraction_script;
    // SatBotBotLevelInteraction satBotLevelInteraction_script;
    
    

    // Start is called before the first frame update
    void Start()
    {
        gearMove_script = Gears.GetComponent<GearMove>();  
        luzMove_script = Luz.GetComponent<LuzMove>();
        bruteMove_script = Brute.GetComponent<BruteMove>();
        pumpMove_script = Pump.GetComponent<PumpMove>();
        satMove_script = Sat.GetComponent<SatMove>();
        
        gearbotLevelInteraction_script = Gears.GetComponent<GearbotLevelInteraction>();  
        luzbotLevelInteraction_script = Luz.GetComponent<LuzbotLevelInteraction>();
        bruteBotLevelInteraction_script = Brute.GetComponent<BruteBotLevelInteraction>();
        // pumpBotLevelInteraction_script = Pump.GetComponent<PumpBotLevelInteraction>();
        // satBotLevelInteraction_script = Sat.GetComponent<SatBotLevelInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        // var playerScripts = new Component[] {gearMove_script, luzMove_script, bruteMove_script, pumpMove_script, satMove_script};
        if (Input.GetKeyDown("t"))
        {
            if(gearMove_script.toggleSelected == true){
                gearMove_script.toggleSelectedState();
                luzMove_script.toggleSelectedState();
                gearbotLevelInteraction_script.toggleSelectedState();
                luzbotLevelInteraction_script.toggleSelectedState();
            }
            else if(luzMove_script.toggleSelected == true){
                bruteMove_script.toggleSelectedState();
                luzMove_script.toggleSelectedState();
                bruteBotLevelInteraction_script.toggleSelectedState();
                luzbotLevelInteraction_script.toggleSelectedState();
            }
            else if(bruteMove_script.toggleSelected == true){
                bruteMove_script.toggleSelectedState();
                pumpMove_script.toggleSelectedState();
                bruteBotLevelInteraction_script.toggleSelectedState();
                // pumpLevelInteraction_script.toggleSelectedState();
            }
            else if(pumpMove_script.toggleSelected == true){
                pumpMove_script.toggleSelectedState();
                satMove_script.toggleSelectedState();
                // pumpLevelInteraction_script.toggleSelectedState();
                // satLevelInteraction_script.toggleSelectedState();
            }
            else if(satMove_script.toggleSelected == true){
                satMove_script.toggleSelectedState();
                gearMove_script.toggleSelectedState();
                // satLevelInteraction_script.toggleSelectedState();
                gearbotLevelInteraction_script.toggleSelectedState();
            }
        }
        
    }
}
