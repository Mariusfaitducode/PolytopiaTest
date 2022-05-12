using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : MonoBehaviour
{
    

    public List<Item> collection;
    // Start is called before the first frame update
    void Start()
    {
        collection = new List<Item>();
    }

    public Item FindWithName(string name)
    {
        foreach (Item var in collection)
        {
            if (var.name.Equals(name))
            {
                return var;
            }
        }
        return default;
    }

    public void DispList()
    {
        foreach (Item var in collection)
        {
            print(var.name + " == " + var.quantite);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
