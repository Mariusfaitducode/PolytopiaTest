using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateauJeu : MonoBehaviour
{
    public GameObject terrain_0;

    public MapGenerator mapGen_0;

    public MapGenerator mapGen_1;
    
    public Case[,] grid;

    public Personnage player;

    private bool validate = false;
    public int level;

    void Start()
    {
        grid = new Case[Constants.MapWidth, Constants.MapHeight];
        level = 0;
        //InitPlateauJeu();
        mapGen_0.Generate3dMap(true, level);
        level += 1;
        //limite.InitLimite();
        
    }

    public void CleanTerrain()
    {
        
       DestroyImmediate(GameObject.FindGameObjectWithTag("CaseCube"));
    }

    public void SetPlateau()
    {
        
    }

    private void Update()
    {
        //print("bool=");
        //print(level);
        //print(player.exit);
        if (player.exit && !validate)
        {
            print("second level");
            validate = true;
            CleanTerrain();
            terrain_0.SetActive(false);
            if (level == 1)
            {
                grid.Initialize();
                grid = new Case[Constants.Map_2, Constants.Map_2];
            }
            mapGen_1.Generate3dMap(true, level);
        }
    }
}
