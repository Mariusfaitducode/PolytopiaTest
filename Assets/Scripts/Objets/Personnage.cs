using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personnage : MonoBehaviour
{
    public PlateauJeu plateau;
    
    private string name;
    
    //private enum type {Explorateur};
    //private float life;
    //private int mouvements; //portée du joueur
    //private int actions; //nbr d'actions du joueur
    
    private bool _isSelect;

    public float vitesse = 15f;

    private float height;

    Deplacements mouv;

    public Camera defaultCam;
    public Camera playerCam;

    public bool exit;

    public int level = 0;
    
/*
    public Vector3 ReturnPlateauPos()
    {
        float tabX = transform.position.x + Constants.MapWidth * Constants.CaseSize / 2;
        float tabY = transform.position.z + Constants.MapWidth * Constants.CaseSize / 2;
        Vector3 position = new Vector3( tabX, transform.position.y, tabY);

        return position;
    }*/

    public void Start()
    {
        transform.position = new Vector3(0, 60, 0);
    }

    public Vector2 ReturnCaseRef(int size)
    {
        int tabX = (int)((transform.position.x ) / Constants.CaseSize + size/2)  ;
        int tabY = (int)((transform.position.z )/ Constants.CaseSize + size/2);
        Vector2 position = new Vector3( tabX, tabY);

        return position;
    }

    public Case ReturnCase(int size)
    {
        int i = (int)ReturnCaseRef(size).x;
        int j = (int)ReturnCaseRef(size).y;
        return plateau.grid[i, j];
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

    void FixedUpdate()
    {
        //mouv.mouvCam = playerCam.GetComponent<CameraMouvement>();

        if ( _isSelect )
        {
            int size = 0;
            
            if (level == 0)
            {
                size = Constants.MapWidth;
            }

            if (level == 1)
            {
                size = Constants.Map_2;
            }
            if (!exit)
            {
                
                mouv.KeyDeplacement(vitesse, ReturnCase(size));
            }

            if (exit)
            {
                transform.position = new Vector3(0, 60, 0);
                exit = false;
            }
            mouv.KeyRotation();
            
        }
    }
}
