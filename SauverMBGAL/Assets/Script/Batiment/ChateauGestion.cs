using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChateauGestion : MonoBehaviour
{
    private int vie = 200;
    public const int logement = 10;
    public const long prix = 100;
    public int recolteor = 0;
    public int recoltenourriture = 0;
    public GameObject joueur;
    public bool Ally;

    public int Vie
    {
        get => vie;
        set => vie = value;
    }
    
    void Update()
    {
        if (recolteor != 0)
        {
            
            GameObject clone = GameObject.FindGameObjectWithTag("Player");
            Game player = clone.GetComponent<Game>();
            player.argent += recolteor;
            recolteor = 0;
        }
        if (recoltenourriture != 0)
        {
            
            GameObject clone = GameObject.FindGameObjectWithTag("Player");
            Game player = clone.GetComponent<Game>();
            player.nourriture += recoltenourriture;
            recoltenourriture = 0;
        }

        
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Villageois Allié")
        {
            Ouvrier ouvrier = other.gameObject.GetComponent<Ouvrier>();
            recolteor += ouvrier.stockor;
            recoltenourriture += ouvrier.stocknourriture;
            ouvrier.stockor = 0;
            
        }
    }
}
