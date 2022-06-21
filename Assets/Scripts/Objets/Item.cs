using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
   
    public string name;
    public int quantite = 0;

    public GameObject itemOnScreen;
    
    

    public Item(string name)
    {
        this.name = name;
        this.quantite = 1;
    }

    public void IncrementQuantite()
    {
        this.quantite += 1;
    }
}
