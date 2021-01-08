using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    public int sceneToGoTo;
    // private string selectedHero;

    void Start()
    {
        sceneToGoTo = 1;
        // selectedHeroName = PlayerPrefs.GetString("selectedHero");
        // print(selectedHeroName);
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

//================= Character Selection =====================
    public void setPrefsGear()
    {
        PlayerPrefs.SetInt("selectedHero", 1);
    }
    public void setPrefsLuz()
    {
        PlayerPrefs.SetInt("selectedHero", 2);
    }
    public void setPrefsBrute()
    {
        PlayerPrefs.SetInt("selectedHero", 3);
    }
    public void setPrefsPump()
    {
        PlayerPrefs.SetInt("selectedHero", 4);
    }
    public void setPrefsSat()
    {
        PlayerPrefs.SetInt("selectedHero", 5);
    }
    
    // public void deselectAll()
    // {
    //     gearMove_script.toggleSelected = false;
    //     luzMove_script.toggleSelected = false;
    //     bruteMove_script.toggleSelected = false;
    //     pumpMove_script.toggleSelected = false;
    //     satMove_script.toggleSelected = false;
    // }

    // public void selectGear()
    // {
    //     deselectAll();
    //     gearMove_script.toggleSelected = true;
    // }
    // public void selectLuz()
    // {
    //     deselectAll();
    //     luzMove_script.toggleSelected = true;
    // }
    // public void selectBrute()
    // {
    //     deselectAll();
    //     bruteMove_script.toggleSelected = true;
    // }
    // public void selectPump()
    // {
    //     deselectAll();
    //     pumpMove_script.toggleSelected = true;
    // }
    // public void selectSat()
    // {
    //     deselectAll();
    //     satMove_script.toggleSelected = true;
    // }

    // // Update is called once per frame
    // public void Toggle()
    // {
    //     // var playerScripts = new Component[] {gearMove_script, luzMove_script, bruteMove_script, pumpMove_script, satMove_script};

    //     {
    //         //gear to luz
    //         if(gearMove_script.toggleSelected == true){
    //             // gearMove_script.toggleSelectedState();
    //             // luzMove_script.toggleSelectedState();
    //             // gearbotLevelInteraction_script.toggleSelectedState();
    //             selectLuz();
    //             cameraFollow_script.togglePlayerFollow(Luz);
    //         }
    //         //luz to brute
    //         else if(luzMove_script.toggleSelected == true){
    //             // bruteMove_script.toggleSelectedState();
    //             // luzMove_script.toggleSelectedState();
    //             // bruteBotLevelInteraction_script.toggleSelectedState();
    //             selectBrute();
    //             cameraFollow_script.togglePlayerFollow(Brute);
    //         }
    //         //brute to pump
    //         else if(bruteMove_script.toggleSelected == true){
    //             // bruteMove_script.toggleSelectedState();
    //             // pumpMove_script.toggleSelectedState();
    //             // bruteBotLevelInteraction_script.toggleSelectedState();
    //             // pumpLevelInteraction_script.toggleSelectedState();
    //             selectPump();
    //             cameraFollow_script.togglePlayerFollow(Pump);
    //         }
    //         //pump to sat
    //         else if(pumpMove_script.toggleSelected == true){
    //             // pumpMove_script.toggleSelectedState();
    //             // satMove_script.toggleSelectedState();
    //             // pumpLevelInteraction_script.toggleSelectedState();
    //             // satLevelInteraction_script.toggleSelectedState();
    //             selectSat();
    //             cameraFollow_script.togglePlayerFollow(Sat);
    //         }
    //         //sat to gears
    //         else if(satMove_script.toggleSelected == true){
    //             // satMove_script.toggleSelectedState();
    //             // gearMove_script.toggleSelectedState();
    //             // satLevelInteraction_script.toggleSelectedState();
    //             // gearbotLevelInteraction_script.toggleSelectedState();
    //             selectGear();
    //             cameraFollow_script.togglePlayerFollow(Gears);
    //         }
    //     }
        
    // }

    
}
