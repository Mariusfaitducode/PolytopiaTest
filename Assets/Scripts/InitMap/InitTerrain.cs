using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTerrain : MonoBehaviour
{
    public GameObject caseCube;
    public PlateauJeu plateau;

    public CaseType.DecorType[] decorList;

    private System.Random ran = new System.Random();

    private int arbre = 0;
    private int buisson = 0;
    private int pierre = 0;
    private int sable = 0;

    public CaseType.DecorType FindDecorWithName(string name)
    {
        for (int i = 0; i < decorList.Length; i++)
        {
            if (decorList[i].name.Equals(name))
            {
                return decorList[i];
            }
        }

        return default;
    }
    
    public void GenerateTerrain(float [,] heightMap, CaseType.TerrainType[] regions)
    {

        for ( int y = 0; y < Constants.MapWidth; y++){
            for ( int x = 0; x < Constants.MapHeight; x++){
                
                float currentHeight = heightMap [x, y];

                for (int i = 0; i < regions.Length; i++){
                    if (currentHeight <= regions[i].height)
                    {
                        GameObject obj = Instantiate(caseCube);

                        obj.transform.parent = gameObject.transform;  //On place les cubes dans le bon dossier
                        
                        plateau.grid[x, y] = new Case(regions[i], currentHeight, x, y, obj);

                        GenerateDecor(plateau.grid[x,y]);
                        
                        
                        break;
                    }
                }
            }
        }

        print("arbre =" + arbre + "\npierre =" + pierre + "\nsable = " + sable + "\nbuisson = " + buisson);
    }
    
    public void GenerateDecor( Case newCase)
    {

        if (newCase.typeRegion.name.Equals(("Sand")))
        {
            SandWorld(newCase);
        }
        else if (newCase.typeRegion.name.Equals("LowLand"))
        {
            LowLandWorld(newCase);
        }

        else if (newCase.typeRegion.name.Equals("Land"))
        { 
            MidLandWorld(newCase);
        }
        
        else if (newCase.typeRegion.name.Equals("HighLand"))
        {
            HighLandWorld(newCase);
        }
        
        else if (newCase.typeRegion.name.Equals("Mountain"))
        {
            MountainWorld(newCase);
        }
        
        else if (newCase.typeRegion.name.Equals("HighMountain"))
        {
            HighMountainWorld(newCase);
        }
        
    }

    public void SandWorld(Case newCase)
    {
        GameObject[] newSand = default;
        int randNumber = ran.Next(1, 10);
            
        if (randNumber < 3)
        {
            newSand = new GameObject[ran.Next(1, 4)];
            for (int i = 0; i < newSand.Length; i++)
            {
                newSand[i] = Instantiate(FindDecorWithName("sable").prefab);
                PlacementDecor(newSand[i], newCase);
                sable += 1;
            }
                
        }
    }
    public void LowLandWorld(Case newCase)
    {
        GameObject newBuisson = default;
        GameObject newTree = default;
        int randNumber = ran.Next(1, 10);
        if (randNumber < 7)
        {
            newBuisson = Instantiate(FindDecorWithName("buisson").prefab);
            
            ChangeScale(newBuisson, 10);
            buisson += 1;
        }
        if (randNumber == 1) //Arbre pin
        {
            newTree = Instantiate(FindDecorWithName("pin").prefab);
            arbre += 1;

        }
        else if (randNumber == 2 || randNumber == 3) //Arbre classique
        {
            newTree = Instantiate(FindDecorWithName("arbre").prefab);
            arbre += 1;

        }
        ChangeColor(newTree);
        ChangeScale(newTree,10);
        PlacementDecor(newTree, newCase);
        if (newTree != default && newBuisson != default)
        {
            //newBuisson = Instantiate(FindDecorWithName("buisson").prefab);
            PlacementSecondDecor(newBuisson, newCase, newTree);
        }
        else
        {
            PlacementDecor(newBuisson, newCase);
        }
    }
    public void MidLandWorld(Case newCase)
    {
        GameObject newTree = default;
        int randNumber = ran.Next(1, 10);
        if (randNumber == 1)
        {
            newTree = Instantiate(FindDecorWithName("arbre").prefab);
            arbre += 1;
        }
        else if (randNumber == 2 || randNumber == 3)
        {
            newTree = Instantiate(FindDecorWithName("pin").prefab);
            arbre += 1;
        }
        ChangeColor(newTree);
        ChangeScale(newTree,10);
        PlacementDecor(newTree, newCase);
    }
    public void HighLandWorld(Case newCase)
    {
        GameObject newTree = default;
        GameObject newRoc = default;
        if (ran.Next(1, 4) == 1)
        {
            newTree = Instantiate(FindDecorWithName("sapin").prefab);
            arbre += 1;
        }

        if (ran.Next(1, 8) == 1)
        {
            newRoc = Instantiate(FindDecorWithName("pierre").prefab);
            pierre += 1;
        }
        ChangeColor(newTree);
        ChangeScale(newTree, 10);
        PlacementDecor(newTree, newCase);
        if (newTree != default && newRoc != default)
        {
            //newBuisson = Instantiate(FindDecorWithName("buisson").prefab);
            PlacementSecondDecor(newRoc, newCase, newTree);
        }
        else
        {
            PlacementDecor(newRoc, newCase);
        }
    }
    public void MountainWorld(Case newCase)
    {
        GameObject[] newRoc = default;
        GameObject newTree = default;
        int randNumber = ran.Next(1, 10);
        if (randNumber == 1)
        {
            newTree = Instantiate(FindDecorWithName("tronc").prefab);
            arbre += 1;
            ChangeScale(newTree, 10);
            PlacementDecor(newTree, newCase);
        }
        else if (randNumber == 2)
        {
            int length;
            int randNumber2 = ran.Next(1, 7);
            if (randNumber2 < 4)
            {
                length = 1;
            }
            else if (randNumber2 < 6)
            {
                length = 2;
            }
            else
            {
                length = 3;
            }
                
            newRoc = new GameObject[length];
            for (int i = 0; i < newRoc.Length; i++)
            {
                newRoc[i] = Instantiate(FindDecorWithName("pierre").prefab);
                pierre += 1;
                
                ChangeScale(newRoc[i], 10);
                PlacementDecor(newRoc[i], newCase);
            }
                
        }
    }
    public void HighMountainWorld(Case newCase)
    {
        GameObject[] newRoc = default;
        int randNumber = ran.Next(1, 10);
            
        if (randNumber < 3)
        {
            newRoc = new GameObject[ran.Next(1, 4)];
            for (int i = 0; i < newRoc.Length; i++)
            {
                newRoc[i] = Instantiate(FindDecorWithName("pierre").prefab);
                pierre += 1;
                PlacementDecor(newRoc[i], newCase);
            }
        }
    }


    public void ChangeColor(GameObject decor) //Change le deuxième matériel soit les feuilles
    {
        if (decor != default)
        {
            Vector4 newColor = new Vector4((float)ran.NextDouble()/8, (float)ran.NextDouble()/5, 
                (float)ran.NextDouble()/100, (float)ran.NextDouble()/10);
            decor.GetComponent<MeshRenderer>().materials[1].color += new Color(newColor.x,newColor.y,newColor.z,newColor.w);
        }
    }

    public void ChangeScale(GameObject decor, int amplitude)
    {
        if (decor != default)
        {
            int changeScale = ran.Next(-amplitude, amplitude);
            decor.transform.localScale += new Vector3(changeScale, changeScale, changeScale);
        }
    }
    
    //Placement des prefabs
    public void PlacementDecor(GameObject decor, Case newCase) //3 de décalage max par rapport au centre -> bien pour arbre
    {
        if (decor != default)
        {
            decor.transform.parent = newCase.caseCube.transform;
            float posX = newCase.caseCube.transform.position.x + ran.Next(-3, 3);
            float posZ = newCase.caseCube.transform.position.z + ran.Next(-3, 3);
            float posY = newCase.surfaceHeight;

            decor.transform.position += new Vector3(posX,posY, posZ);
            decor.transform.Rotate(new Vector3(0,0, ran.Next(0,360)));
        }
    }

    public void PlacementSecondDecor(GameObject decor, Case newCase, GameObject lastDecor)
    {
        decor.transform.parent = newCase.caseCube.transform;

        float magnitude = 0;
        
        float posX = 0;
        float posY = newCase.surfaceHeight;
        float posZ = 0;
        
        while (magnitude < 2)
        {
            print("calcul");  // moins de 500 itérations pour 2500 cases
            posX = newCase.caseCube.transform.position.x + ran.Next(-3, 3);
            posZ = newCase.caseCube.transform.position.z + ran.Next(-3, 3);
            

            float vectX = posX - lastDecor.transform.position.x;
            float vectZ = posZ - lastDecor.transform.position.z;
        
            magnitude = Mathf.Sqrt(Mathf.Pow(vectX, 2) + Mathf.Pow(vectZ, 2));
        }

        decor.transform.position += new Vector3(posX,posY, posZ);
        decor.transform.Rotate(new Vector3(0,0, ran.Next(0,360)));
    }
    
    
}


