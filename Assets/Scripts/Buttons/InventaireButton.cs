using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventaireButton : MonoBehaviour
{
    public GameObject invent;

    public bool open = false;
    public bool lastAction;

    public void OnClick()
    {
        if (!open)
        {
            invent.SetActive(true);
            open = true;
        }
        else
        {
            invent.SetActive(false);
            open = false;
        }
    }
   
    void Start()
    {
        open = false;
    }
    
    
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (!open)
            {
                invent.SetActive(true);
            }
            else
            {
                invent.SetActive(false);
            }

            lastAction = true;
        }
        else
        {
            if (lastAction)
            {
                open = !open;
                lastAction = false;
            }
        }
    }
}
