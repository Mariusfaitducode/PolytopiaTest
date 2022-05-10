using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActions : MonoBehaviour
{
    Deplacements mouv;
    private bool _isSelect;
    private bool _canMouv = false;
    public GameObject camera;
    
    void FixedUpdate()
    {
        if ( camera.GetComponent<Camera>().enabled )
        {
            _isSelect = true;
            if (_canMouv == false)
            {
                mouv = gameObject.AddComponent<Deplacements>();
                _canMouv = true;
            }
            if (!mouv.KeyRotation())
            {
                mouv.KeyDeplacement(50f);
            }
        }
        else
        {
            _isSelect = false;
            Destroy(gameObject.GetComponent<Deplacements>());
            _canMouv = false;
        }
    }
}
