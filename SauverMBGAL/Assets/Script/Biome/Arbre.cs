using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbre : MonoBehaviour
{
    private int pv;
    private int ressource;

    public Arbre()
    {
        pv = 100;
        ressource = 100;
    }

    public void detruire()
    {
        Destroy(this.gameObject);
    }
}
