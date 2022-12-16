using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacements : MonoBehaviour
{
    private float height;

    public bool KeyDeplacement(float vitesse, Case actualCase)
    {
        if (!Input.GetKey(KeyCode.RightShift) && Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            Vector3 lastPos = transform.position;
            
            transform.Translate(Vector3.forward * vitesse * Time.fixedDeltaTime *
                                Input.GetAxis("Vertical")); //Avance sur z
            
            transform.Translate(Vector3.right * vitesse * Time.fixedDeltaTime *
                                Input.GetAxis("Horizontal")); //Avance sur x

            height = transform.position.y;

            float newHeight = actualCase.caseCube.transform.position.y * 2;

            //print(height + " // " + newHeight);

            if (height + 4f >= newHeight)
            {
                //print("ok");
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, newHeight,
                    gameObject.transform.position.z);
                //print(actualCase.typeRegion.name);
                height = newHeight;
            }
            else
            {
                //print("ko");
                gameObject.transform.position = lastPos;
            }

            return true;
        }

        return false;
    }

    public void KeyDeplacement2(float vitesse)
    {
        if (!Input.GetKey(KeyCode.RightShift) && Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            

            transform.Translate(Vector3.forward * vitesse * Time.fixedDeltaTime *
                                Input.GetAxis("Vertical")); //Avance sur z

            transform.Translate(Vector3.right * vitesse * Time.fixedDeltaTime *
                                Input.GetAxis("Horizontal")); //Avance sur x
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
