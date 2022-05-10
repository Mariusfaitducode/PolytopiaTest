using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personnage : MonoBehaviour
{
    public PlateauJeu plateau;
    
    private string name;
    //private enum type {Explorateur};
    private float life;
    private int mouvements; //portée du joueur
    private int actions; //nbr d'actions du joueur
    private bool _isSelect;

    public float vitesse = 10f;

    private float height;

    Deplacements mouv;

    public Camera defaultCam;
    public Camera playerCam;

    public Vector3 ReturnPlateauPos()
    {
        float tabX = transform.position.x + Constants.MapWidth * Constants.CaseSize / 2;
        float tabY = transform.position.z + Constants.MapWidth * Constants.CaseSize / 2;
        Vector3 position = new Vector3( tabX, transform.position.y, tabY);

        return position;
    }
    public Vector3 ReturnCase()
    {
        int tabX = (int)((transform.position.x ) / Constants.CaseSize + Constants.MapWidth/2)  ;
        int tabY = (int)((transform.position.z )/ Constants.CaseSize + Constants.MapHeight/2);
        Vector3 position = new Vector3( tabX, transform.position.y, tabY);

        return position;
    }
    private void OnMouseDown() //Choix de la caméra -> controle du personnage
    {
        if (!_isSelect)
        {
            defaultCam.enabled = false;
            playerCam.enabled = true;
            _isSelect = true;
            mouv = gameObject.AddComponent<Deplacements>();
        }
        else
        {
            playerCam.enabled = false;
            defaultCam.enabled = true;
            _isSelect = false;
            Destroy(gameObject.GetComponent<Deplacements>());
        }
    }

    void Start()
    {
        
        //int i = (int)ReturnCase().x;
        //int j = (int)ReturnCase().z;
        //height = plateau.grid[i, j].typeRegion.height * plateau.grid[i,j].altitude + 1;
        //height = transform.position.y;
    }

    void FixedUpdate()
    {
        if ( _isSelect )
        {
            height = transform.position.y;
            Vector3 lastPos = transform.position;
            
            if (mouv.KeyDeplacement(vitesse))
            {
                //print(ReturnPlateauPos());
                //print(ReturnCase());
                
                int i = (int)ReturnCase().x;
                int j = (int)ReturnCase().z;

                //float newHeight = plateau.grid[i, j].typeRegion.height * plateau.grid[i,j].altitude + 1;
                float newHeight = plateau.grid[i, j].caseCube.transform.position.y * 2 + 1;
                
                print(height + " // " + newHeight);

                if (height + 4f >= newHeight)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x,newHeight,gameObject.transform.position.z);
                    print(plateau.grid[i,j].typeRegion.name);
                    height = newHeight;
                }
                else
                {
                    gameObject.transform.position = lastPos;
                }
            }
            mouv.KeyRotation();
        }
    }

}
