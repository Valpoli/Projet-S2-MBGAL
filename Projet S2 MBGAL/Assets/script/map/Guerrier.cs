using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guerrier : MonoBehaviour
{
    private int vie = 50;
    private int dégat = 10;
    public const int logement = 1;
    public const long prixOr = 100;
    public const long prixNouriture = 100;
    private bool isKO = false;

    public int Vie
    {
        get => vie;
        set => vie = value;
    }

    public int Dégat
    {
        get => dégat;
        set => dégat = value;
    }
    
    public bool IsKO
    {
        get => isKO;
        set => isKO = value;
    }

    private void Update()
    {
        if (Vie < 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "Maison")
        {
            Maison Cible = other.gameObject.GetComponent<Maison>();
            int CibleVie = Cible.Vie;
            CibleVie -= dégat;
            if (CibleVie < 0)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.name == "Chateau")
        {
            Chateau Cible = other.gameObject.GetComponent<Chateau>();
            int CibleVie = Cible.Vie;
            CibleVie -= dégat;
            if (CibleVie < 0)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.name == "Caserne")
        {
            Caserne Cible = other.gameObject.GetComponent<Caserne>();
            int CibleVie = Cible.Vie;
            CibleVie -= dégat;
            if (CibleVie < 0)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.name == "Champ")
        {
            Champ Cible = other.gameObject.GetComponent<Champ>();
            int CibleVie = Cible.Vie;
            CibleVie -= dégat;
            if (CibleVie < 0)
            {
                Destroy(other.gameObject);
            };
        }
        if (other.gameObject.name == "Tour")
        {
            Tour Cible = other.gameObject.GetComponent<Tour>();
            int CibleVie = Cible.Vie;
            CibleVie -= dégat;
            if (CibleVie < 0)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.name == "Guerrier")
        {
            Guerrier Cible = other.gameObject.GetComponent<Guerrier>();
            int CibleVie = Cible.Vie;
            CibleVie -= dégat;
            if (CibleVie < 0)
            {
                Destroy(other.gameObject);
            }
        }

        
        
    }
}
