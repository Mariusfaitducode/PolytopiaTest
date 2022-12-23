using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCondition : MonoBehaviour
{
    public bool step2;
    public Personnage player;
    
    // Update is called once per frame
    void Update()
    {
        if (player.endScene && step2)
        {
            print("stop");
            step2 = false;
            player.exit = true;
        }
    }
}
