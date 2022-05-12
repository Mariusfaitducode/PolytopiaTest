using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using UnityEngine;

public class CaseActions : MonoBehaviour
{
    //public Personnage player;

    //public PlateauJeu plateau;

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
        print("CUUUT THIS TREE");
        print(other);
        if (Input.GetKey(KeyCode.Space))
        {
            print("destroy");

            Item item = invent.FindWithName(other.gameObject.tag);

            if ( item != default)
            {
                item.IncrementQuantite();
            }
            else
            {
                invent.collection.Add(new Item(other.gameObject.tag));
            }
            
            invent.DispList();
            
            Destroy(other.gameObject);
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
