using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Arbre : MonoBehaviour
{
    public int pv  = 100;
    public int ressource = 100;
    

    private void Update()
    {
        if (pv <= 0)
        {
            Destroy(gameObject);
            Game clonePartie = GameObject.FindGameObjectWithTag("Player").GetComponent<Game>();
            clonePartie.map.matrix[Construction.posDansMatrice(gameObject.transform.position).Item1,Construction.posDansMatrice(gameObject.transform.position).Item2] = new Case(Case.Biome.PLAINE);
        }
    }
}
