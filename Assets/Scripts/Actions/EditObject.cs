using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditObject : MonoBehaviour
{
    private InitTerrain terrain;
    
    public CaseType.TerrainType[] regions;
    
    private System.Random ran = new System.Random();

    public void Edit(GameObject obj, CaseType.TerrainType region)
    {
        if (obj.tag.Equals("bois"))
        {
            GiveColor(obj, 1, region.colour); 
            ChangeColor2(obj, 1);
        }
        else
        {
            GiveColor(obj, 0, region.colour);
            ChangeColor2(obj, 0);
        }
        
        
        ChangeScale(obj, 50);
    }

    public void Biodiversite(Case actualCase, PlateauJeu plateau)
    {
        int posX = (int)actualCase.tabRef.x;
        int posY = (int)actualCase.tabRef.y;
        print("x = "+ posX +"  y = "+ posY);

        for (int i = posX - 1; i <= posX + 1; i++)
        {
            for (int j = posY - 1; j <= posY + 1; j++)
            {
                ChangeColourCube(plateau, i, j);

            }
        }
    }

    public void ChangeColourCube(PlateauJeu plateau, int i, int j)
    {
        plateau.grid[i, j].caseCube.GetComponent<MeshRenderer>().material.color = Color.green;
    }
    
    //public void GiveColorWithHeight()
    
    
    
    public void GiveColor(GameObject decor, int indexMat, Color colour) //Change le deuxième matériel soit les feuilles
    {
        if (decor != default)
        {
           
            decor.GetComponent<MeshRenderer>().materials[indexMat].color = colour;
        }
    }
    
    public void ChangeScale(GameObject decor, int amplitude)
    {
        if (decor != default)
        {
            int changeScale = ran.Next(0, 2 * amplitude);
            decor.transform.localScale += new Vector3(changeScale, changeScale, changeScale);
        }
    }
    
    public void ChangeColor2(GameObject decor, int indexMat) //Change le deuxième matériel soit les feuilles
    {
        if (decor != default)
        {
            Vector4 newColor = new Vector4((float)-ran.NextDouble()/10, (float)ran.NextDouble()/20, 
                (float)ran.NextDouble()/10, (float)ran.NextDouble()/4);
            decor.GetComponent<MeshRenderer>().materials[indexMat].color -= new Color(newColor.x,newColor.y,newColor.z,newColor.w);
        }
    }
}
