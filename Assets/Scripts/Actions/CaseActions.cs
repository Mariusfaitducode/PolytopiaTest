using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class CaseActions : MonoBehaviour
{
    public Personnage player;

    //public PlateauJeu plateau;

    public Inventaire invent;

    private bool cutTree = false;
    private bool putTree = false;

    public AfficheInvent.ItemOnScreen selected;

    public bool firstAction;
    private bool lastAction;

    public EditObject edit;

   

    public bool GetCutTree(){return cutTree;}
    public bool GetPutTree(){return putTree;}

    void Start()
    {
        //player = gameObject.GetComponent<Personnage>();
        selected.name = default;
        firstAction = true;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
       PutObject();
       
    }

    public void OnTriggerStay(Collider other)
    {
        //print("CUUUT THIS TREE");
        //print(other);
        TakeObject(other);
        
    }

    public void TakeObject(Collider other)
    {
        //cutTree = false;
        if (selected.name == default && Input.GetKey(KeyCode.Space) &&
            !other.gameObject.CompareTag("CaseCube") && !other.gameObject.CompareTag("Sortie"))
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

    public void PutObject()
    {
        lastAction = true;
        //  putTree = false;
        if (selected.name != default)
        {
            if (Input.GetKey(KeyCode.Space) && firstAction)
            {
                Inventaire.Item obj = invent.FindWithName(selected.name);

                if (obj.quantite > 0)
                {
                    GameObject objet = Instantiate(obj.prefab);

                    
                    objet.transform.position = gameObject.transform.position;

                    Vector3 position = objet.transform.position;

                    int size = Constants.GetConstant(player.level);

                    Case actualCase = player.ReturnCase(size);
                    
                    edit.Edit(objet, actualCase.typeRegion);
                    
                    edit.Biodiversite(actualCase, player.plateau);


                    invent.DecrementQuantite(obj);
                    putTree = true;
                    firstAction = false;
                    lastAction = false;
                    //objet.transform.parent = gameObject.transform;
                }
            }
            else if (lastAction && !Input.GetKey(KeyCode.Space))
            {
                
                firstAction = true;
            }

            
        }
    }
}
