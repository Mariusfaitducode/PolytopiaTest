using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AfficheInvent : MonoBehaviour
{
    
    [System.Serializable]
    public struct ItemOnScreen 
    {
        public TextMeshProUGUI name;
        public TextMeshProUGUI quantite;
        public RawImage image;
    }
    
    public ItemOnScreen[] collection;
    
    public Inventaire invent;

    public CaseActions action;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (action.cutTree)
        {
            actualizeItems();
        }
    }
    
    public void actualizeItems()
    {
        //this.quantite;

        for (int i = 1; i < collection.Length; i++)
        {
            ItemOnScreen var = collection[i];
            
            if (var.name.text != default)
            {
                Inventaire.Item item = invent.FindWithName(var.name.text);

                collection[i].quantite.text = item.quantite.ToString();
            }

            
        }
        action.cutTree = false;
    }
}
