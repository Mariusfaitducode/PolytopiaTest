using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : MonoBehaviour
{
    public bool activate;

    public void KeyDeplacement()
    {
        if (Input.GetKey(KeyCode.C))
        {
            activate = true;
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                //Zoom camera
                transform.Translate(Vector3.forward * 90f * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));
                //transform.Translate(Vector3.right * vitesse * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));
            
                //Rotation camera
                transform.Rotate(Vector3.right * 90f * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
            }
        }
        else
        {
            activate = false;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        KeyDeplacement();
    }
}
