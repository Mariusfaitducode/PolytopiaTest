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
        public string name;
        public TextMeshProUGUI quantite;
        public RawImage isSelect;
        
    }
    
    public ItemOnScreen[] collection;
    
    public Inventaire invent;

    public CaseActions action;

    public InventaireButton button;

    public int index = 0;
    public bool lastAction;
    public bool firstAction;

    
    
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
        SelectItem();
    }
    
    public void actualizeItems()
    {
        //this.quantite;

        for (int i = 1; i < collection.Length; i++)
        {
            ItemOnScreen var = collection[i];
            
            if (var.name != default)
            {
                Inventaire.Item item = invent.FindWithName(var.name);

                collection[i].quantite.text = item.quantite.ToString();
            }

            
        }
        action.cutTree = false;
    }

    public void SelectItem()
    {
        lastAction = true;
        if (button.open && firstAction)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                if (Input.GetAxis("Horizontal") != 0)
                {
                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        index += 1;
                        if (index >= collection.Length)
                        {
                            index = 0;
                        }
                    }
                    else  if (Input.GetAxis("Horizontal") < 0)
                    {
                        index -= 1;
                        if (index < 0)
                        {
                            index = collection.Length - 1;
                        
                        }
                    }
                    firstAction = false;
                    lastAction = false;
                    button.isSelect.enabled = false;
                    ClearFond();
                    if (index == 0)
                    {
                        button.isSelect.enabled = true;
                        action.selected = default;
                    }
                    else
                    {
                        collection[index].isSelect.enabled = true;
                        action.selected = collection[index];
                    }
                }
            }
        }
        if (lastAction && Input.GetAxis("Horizontal") == 0)
        {
            firstAction = true;
        }

        if (!button.open)
        {
            ClearFond();
        }
    }

    public void ClearFond()
    {
        //button.isSelect.enabled = false;
        for (int i = 1; i < collection.Length; i++)
        {
            collection[i].isSelect.enabled = false;
        }
    }
    
}
