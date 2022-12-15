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

            Item item = invent.FindWithName(other.gameObject.tag);

            if ( item != default) //Actualiser le nombre d'objets
            {
                item.IncrementQuantite();
                item.itemOnScreen.GetComponentInChildren<TextMeshProUGUI>().SetText(item.name + "\n"+ item.quantite);
            }
            else    //Nouvel objet dans l'inventaire
            {
                invent.collection.Add(new Item(other.gameObject.tag));
                item = invent.FindWithName(other.gameObject.tag);
                
                item.itemOnScreen = Instantiate(invent.itemDispPF);
                item.itemOnScreen.transform.parent = canvas.transform;
                item.itemOnScreen.transform.position = new Vector3(invent.collection.Count * 200,100,0);
                
                item.itemOnScreen.GetComponentInChildren<TextMeshProUGUI>().SetText(item.name + "\n"+ item.quantite);
            }
            
            invent.DispList();
            
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
