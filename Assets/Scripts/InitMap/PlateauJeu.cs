using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateauJeu : MonoBehaviour
{
    public LimiteTerrain limite;

    public MapGenerator mapGen;

    public Case[,] grid = new Case[Constants.MapWidth, Constants.MapHeight];

    void Start()
    {
        //InitPlateauJeu();
        mapGen.Generate3dMap();
        //limite.InitLimite();
    }

    public void CleanTerrain()
    {
        
       // DestroyImmediate(GameObject.FindGameObjectWithTag("CaseCube"));
    }
}
