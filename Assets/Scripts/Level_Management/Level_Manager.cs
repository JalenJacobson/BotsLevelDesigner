using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    public int sceneToGoTo;
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
    void Start()
    {
        sceneToGoTo = 1;
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

    void Update()
    {
        if(sceneToGoTo != 1 && Input.GetKeyDown("q"))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {

        SceneManager.LoadScene(sceneToGoTo);
        // sceneToGoTo = 1;
    }

    public void setSceneToGoTo(int nextScene)
    {
        sceneToGoTo = nextScene;
    }

    public void deselectAll()
    {
        gearMove_script.toggleSelected = false;
        luzMove_script.toggleSelected = false;
        bruteMove_script.toggleSelected = false;
        pumpMove_script.toggleSelected = false;
        satMove_script.toggleSelected = false;
    }

    public void selectGear()
    {
        deselectAll();
        gearMove_script.toggleSelected = true;
    }
    public void selectLuz()
    {
        deselectAll();
        luzMove_script.toggleSelected = true;
    }
    public void selectBrute()
    {
        deselectAll();
        bruteMove_script.toggleSelected = true;
    }
    public void selectPump()
    {
        deselectAll();
        pumpMove_script.toggleSelected = true;
    }
    public void selectSat()
    {
        deselectAll();
        satMove_script.toggleSelected = true;
    }

    // Update is called once per frame
    public void Toggle()
    {
        // var playerScripts = new Component[] {gearMove_script, luzMove_script, bruteMove_script, pumpMove_script, satMove_script};

        {
            //gear to luz
            if(gearMove_script.toggleSelected == true){
                // gearMove_script.toggleSelectedState();
                // luzMove_script.toggleSelectedState();
                // gearbotLevelInteraction_script.toggleSelectedState();
                selectLuz();
                cameraFollow_script.togglePlayerFollow(Luz);
            }
            //luz to brute
            else if(luzMove_script.toggleSelected == true){
                // bruteMove_script.toggleSelectedState();
                // luzMove_script.toggleSelectedState();
                // bruteBotLevelInteraction_script.toggleSelectedState();
                selectBrute();
                cameraFollow_script.togglePlayerFollow(Brute);
            }
            //brute to pump
            else if(bruteMove_script.toggleSelected == true){
                // bruteMove_script.toggleSelectedState();
                // pumpMove_script.toggleSelectedState();
                // bruteBotLevelInteraction_script.toggleSelectedState();
                // pumpLevelInteraction_script.toggleSelectedState();
                selectPump();
                cameraFollow_script.togglePlayerFollow(Pump);
            }
            //pump to sat
            else if(pumpMove_script.toggleSelected == true){
                // pumpMove_script.toggleSelectedState();
                // satMove_script.toggleSelectedState();
                // pumpLevelInteraction_script.toggleSelectedState();
                // satLevelInteraction_script.toggleSelectedState();
                selectSat();
                cameraFollow_script.togglePlayerFollow(Sat);
            }
            //sat to gears
            else if(satMove_script.toggleSelected == true){
                // satMove_script.toggleSelectedState();
                // gearMove_script.toggleSelectedState();
                // satLevelInteraction_script.toggleSelectedState();
                // gearbotLevelInteraction_script.toggleSelectedState();
                selectGear();
                cameraFollow_script.togglePlayerFollow(Gears);
            }
        }
        
    }

    
}
