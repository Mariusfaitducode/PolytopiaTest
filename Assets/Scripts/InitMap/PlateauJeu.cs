using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateauJeu : MonoBehaviour
{
    public GameObject terrain_1;

    public MapGenerator mapGen;

    public Case[,] grid;

    public Personnage player;

    private bool validate = false;
    public int level;

    void Start()
    {
        grid = new Case[Constants.MapWidth, Constants.MapHeight];
        level = 0;
        //InitPlateauJeu();
        mapGen.Generate3dMap(false, level);
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
            terrain_1.SetActive(false);
            if (level == 1)
            {
                grid.Initialize();
                grid = new Case[Constants.Map_2, Constants.Map_2];
            }
            mapGen.Generate3dMap(true, level);
        }
    }
}
