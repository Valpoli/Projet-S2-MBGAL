using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Arbre : MonoBehaviour
{
    public int pv  = 100;
    public int ressource = 100;
    

    public void detruire()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (pv <= 0)
        {
            Destroy(gameObject);
        }
    }
}
