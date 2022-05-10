using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTerrain : MonoBehaviour
{
    public GameObject caseCube;
    public PlateauJeu plateau;

    public GameObject tree;
    
    private System.Random ran = new System.Random();
    
    public void GenerateTerrain(float [,] heightMap, CaseType.TerrainType[] regions)
    {
        //PlateauJeu newPlateau = FindObjectOfType<PlateauJeu> ();

        for ( int y = 0; y < Constants.MapWidth; y++){
            for ( int x = 0; x < Constants.MapHeight; x++){
                
                float currentHeight = heightMap [x, y];

                for (int i = 0; i < regions.Length; i++){
                    if (currentHeight <= regions[i].height)
                    {
                        GameObject obj = Instantiate(caseCube);

                        obj.transform.parent = gameObject.transform;
                        
                        plateau.grid[x, y] = new Case(regions[i], currentHeight, x, y, obj);

                        if (plateau.grid[x, y].typeRegion.name.Equals("Land"))
                        {
                            if (ran.Next(1, 5) == 1)
                            {
                                GameObject newTree = Instantiate(this.tree);

                                newTree.transform.parent = plateau.grid[x, y].caseCube.transform;
                                float posX = plateau.grid[x, y].caseCube.transform.position.x;
                                float posZ = plateau.grid[x, y].caseCube.transform.position.z;

                                newTree.transform.position += new Vector3(posX,currentHeight * Constants.altitude,posZ);
                            }
                        }
                        
                        break;
                    }
                }
            }
        }
        //return newPlateau;
    }
}
