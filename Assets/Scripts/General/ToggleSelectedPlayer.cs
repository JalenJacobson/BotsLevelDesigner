using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSelectedPlayer : MonoBehaviour
{
    public int selectedHeroIndex;
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
    BruteBotLevelInteraction bruteBotLevelInteraction_script;
    
    CameraFollow cameraFollow_script;

    // Start is called before the first frame update
    void Start()
    {
        selectedHeroIndex = PlayerPrefs.GetInt("selectedHero");
        print("This is the selected hero index");
        print(selectedHeroIndex);
        
        gearMove_script = Gears.GetComponent<GearMove>();  
        luzMove_script = Luz.GetComponent<LuzMove>();
        bruteMove_script = Brute.GetComponent<BruteMove>();
        pumpMove_script = Pump.GetComponent<PumpMove>();
        satMove_script = Sat.GetComponent<SatMove>();
        gearbotLevelInteraction_script = Gears.GetComponent<GearbotLevelInteraction>();  
        bruteBotLevelInteraction_script = Brute.GetComponent<BruteBotLevelInteraction>();
        cameraFollow_script = Main_Camera.GetComponent<CameraFollow>();

        selectStartHero();
    }

    public void selectStartHero()
    {
       if(selectedHeroIndex == 1)
       {
           selectGear();
       }
       if(selectedHeroIndex == 2)
       {
           selectLuz();
       }
       if(selectedHeroIndex == 3)
       {
           selectBrute();
       }
       if(selectedHeroIndex == 4)
       {
           selectPump();
       }
       if(selectedHeroIndex == 5)
       {
           selectSat();
       }
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
        cameraFollow_script.togglePlayerFollow(Gears);
    }
    public void selectLuz()
    {
        deselectAll();
        luzMove_script.toggleSelected = true;
        cameraFollow_script.togglePlayerFollow(Luz);
    }
    public void selectBrute()
    {
        deselectAll();
        bruteMove_script.toggleSelected = true;
        cameraFollow_script.togglePlayerFollow(Brute);
    }
    public void selectPump()
    {
        deselectAll();
        pumpMove_script.toggleSelected = true;
        cameraFollow_script.togglePlayerFollow(Pump);
    }
    public void selectSat()
    {
        deselectAll();
        satMove_script.toggleSelected = true;
        cameraFollow_script.togglePlayerFollow(Sat);
    }

    public void Toggle()
    {

        {
            //gear to luz
            if(gearMove_script.toggleSelected == true){
                selectLuz();
                // cameraFollow_script.togglePlayerFollow(Luz);
            }
            
            //luz to brute
            else if(luzMove_script.toggleSelected == true){
                selectBrute();
                // cameraFollow_script.togglePlayerFollow(Brute);
            }
            
            //brute to pump
            else if(bruteMove_script.toggleSelected == true){
                selectPump();
                // cameraFollow_script.togglePlayerFollow(Pump);
            }
            
            //pump to sat
            else if(pumpMove_script.toggleSelected == true){
                selectSat();
                // cameraFollow_script.togglePlayerFollow(Sat);
            }
            //sat to gears
            else if(satMove_script.toggleSelected == true){
                selectGear();
                // cameraFollow_script.togglePlayerFollow(Gears);
            }
        }
        
    }
}
