using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacements : MonoBehaviour
{
    public bool KeyDeplacement(float vitesse)
    {
        if (!Input.GetKey(KeyCode.RightShift) && Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Vector3.forward * vitesse * Time.fixedDeltaTime * Input.GetAxis("Vertical")); //Avance sur z
            transform.Translate(Vector3.right * vitesse * Time.fixedDeltaTime * Input.GetAxis("Horizontal")); //Avance sur x
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool KeyRotation()
    {
        if (Input.GetKey(KeyCode.T))
        {
            
            transform.Rotate(Vector3.up * 90f * Time.fixedDeltaTime); //Tourne autour de y
            //transform.Rotate(Vector3.right * 90f * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
            return true;
        }
        else if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up * -90f * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }
}
