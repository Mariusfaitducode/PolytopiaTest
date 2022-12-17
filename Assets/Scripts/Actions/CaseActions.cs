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

    public Inventaire invent;

    public bool cutTree;

    public AfficheInvent.ItemOnScreen selected;


    void Start()
    {
        //player = gameObject.GetComponent<Personnage>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (selected.name != default)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Inventaire.Item obj = invent.FindWithName(selected.name);

                if (obj.quantite > 0)
                {
                    GameObject objet = Instantiate(obj.prefab);

                    

                    objet.transform.position = gameObject.transform.position;
                    
                    //objet.transform.parent = gameObject.transform;
                }
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        //print("CUUUT THIS TREE");
        //print(other);
        TakeObject(other);
        
    }

    public void TakeObject(Collider other)
    {
        if (Input.GetKey(KeyCode.Space) && !other.gameObject.CompareTag("CaseCube") && !other.gameObject.CompareTag("Sortie"))
        {
            //print("destroy");

            Inventaire.Item item = invent.FindWithName(other.gameObject.tag);
            //print(item.name);

            invent.IncrementQuantite(item);
            
            //invent.DispList();
            
            Destroy(other.gameObject);

            //invent.actualize = true;

            cutTree = true;
        }
    }
}
