using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacements : MonoBehaviour
{
    public CameraMouvement mouvCam;
    public bool KeyDeplacement(float vitesse)
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 && !Input.GetKey(KeyCode.RightShift))
        {
            transform.Translate(Vector3.forward * vitesse * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
            transform.Translate(Vector3.right * vitesse * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool KeyRotation()
    {
        if (Input.GetKey(KeyCode.RightShift) && Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(Vector3.up * 90f * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));
            return true;
        }
        else
        {
            return false;
        }
    }
}
