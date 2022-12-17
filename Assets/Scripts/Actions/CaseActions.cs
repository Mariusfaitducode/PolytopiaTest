using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class CaseActions : MonoBehaviour
{
    //public Personnage player;

    //public PlateauJeu plateau;

    public Canvas canvas;

    public Inventaire invent;

    public bool cutTree;


    void Start()
    {
        //player = gameObject.GetComponent<Personnage>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        //print("CUUUT THIS TREE");
        //print(other);
        if (Input.GetKey(KeyCode.Space) && !other.gameObject.CompareTag("CaseCube") && !other.gameObject.CompareTag("Sortie"))
        {
            //print("destroy");

            Inventaire.Item item = invent.FindWithName(other.gameObject.tag);
            //print(item.name);

            invent.IncrementQuantite(item);
            
            //invent.DispList();
            
            Destroy(other.gameObject);

            //invent.actualize = true;
        }
    }

    public void doSomething()
    {
        //Case actualCase = player.ReturnCase();
        
        //En fonctions du terrain, proposer les actions correspondante
        
        //Récolter
        
        //Construire
    }
}
