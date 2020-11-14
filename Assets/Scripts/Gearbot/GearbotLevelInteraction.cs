using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearbotLevelInteraction : MonoBehaviour
{
    public GameObject level_gearbox_1;
    Gearbox1 level_gearbox_1_script;
    // Start is called before the first frame update
    void Start()
    {
        level_gearbox_1_script = level_gearbox_1.GetComponent<Gearbox1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            level_gearbox_1_script.changeGearPos(1);
        }
        
    }
}
