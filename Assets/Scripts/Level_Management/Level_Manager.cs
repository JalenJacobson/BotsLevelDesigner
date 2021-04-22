using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net.Http;
using System;
using System.Text;

public class Level_Manager : MonoBehaviour
{
    private static readonly HttpClient client = new HttpClient();
    public int sceneToGoTo;
    public Animator transition;
    public float transitionTime = 1f;

    public bool startTheGame;
    public bool gameStarted;

    private int frameCount = 0;
    // private string selectedHero;

    void Start()
    {
        sceneToGoTo = 1;
        // selectedHeroName = PlayerPrefs.GetString("selectedHero");
        // print(selectedHeroName);
        sendState();
    }

    void Update()
    {
        if(startTheGame && !gameStarted)
        {
            LoadNextLevel();
        }

        if(sceneToGoTo != 1 && Input.GetKeyDown("q"))
        {
            LoadNextLevel();
        }

        frameCount++;
        if(frameCount%10 == 0)
        {
            updateScene();
        }
    }

    public void startGame()
    {
        startTheGame = true;
        sendState();

    }

    public void LoadNextLevel()
    {
        gameStarted = true;
        StartCoroutine(LoadLevel(sceneToGoTo));
        // sceneToGoTo = 1;
    }
    
    public void loadCurrentLevel()
    {
        sceneToGoTo = PlayerPrefs.GetInt("currentLevel");
        print(sceneToGoTo);
        SceneManager.LoadScene(sceneToGoTo);
        // this.StartCoroutine(LoadLevel(sceneToGoTo));
        // sceneToGoTo = 1;
    }
    
    public void loadLevelSelectLevel()
    {
        sceneToGoTo = 1;
        SceneManager.LoadScene(sceneToGoTo);
        // StartCoroutine(LoadLevel(sceneToGoTo));
        // sceneToGoTo = 1;
    }
    
    public void loadGameOverLevel()
    {
        sceneToGoTo = 2;
        SceneManager.LoadScene(sceneToGoTo);
        // StartCoroutine(LoadLevel(sceneToGoTo));
        // sceneToGoTo = 1;
    }

    public void setSceneToGoTo(int nextScene)
    {
        sceneToGoTo = nextScene;
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }


//================= Update Network Scene ====================

    public async void sendState()
    {
        
        // time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        var scene = new Scene();
        scene.name = "levelmanager";
        scene.sceneNumber = sceneToGoTo;
        scene.startTheGame = startTheGame;
        
    
        string json = JsonUtility.ToJson(scene);

        // var response = await client.PostAsync("http://74.207.254.19:7000/scene/save", new StringContent(json, Encoding.UTF8, "application/json"));
        var response = await client.PostAsync("http://localhost:7000/scene/save", new StringContent(json, Encoding.UTF8, "application/json"));

        var responseString = await response.Content.ReadAsStringAsync();
    }

    async void updateScene()
    {
        // var positionResponse = await client.PostAsync("http://74.207.254.19:7000/states", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));
        var positionResponse = await client.PostAsync("http://localhost:7000/scene", new StringContent("{\"name\": \"gears\"}", Encoding.UTF8, "application/json"));

        var positionResponseString = await positionResponse.Content.ReadAsStringAsync();
        print(positionResponseString);
        var scene = JsonUtility.FromJson<SceneUpdate>(positionResponseString);
        print(scene.levelmanager.startTheGame);
        startTheGame = scene.levelmanager.startTheGame;
        
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

[Serializable]
public class Scene
{
    public string name;
    public int sceneNumber;
    public bool startTheGame;
}

[Serializable]
public class SceneUpdate
{
    public Scene levelmanager;
}
