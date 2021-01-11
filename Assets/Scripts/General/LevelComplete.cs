using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{

    public int playersReady = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPlayerReady()
    {
        playersReady += 1;
    }
    public void removePlayerReady()
    {
        playersReady -= 1;
    }
}
