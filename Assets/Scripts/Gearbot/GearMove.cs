using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMove : Player
{
    void Start()
    {
        startPos = new Vector3(47f, 0.58f, -246f);
        transform.position = startPos;
    }
}
