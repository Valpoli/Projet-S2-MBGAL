using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChateauGestion : MonoBehaviour
{
    private int vie = 50;
    public const int logement = 10;
    public const long prix = 100;
    public int recolte = 0;
    public GameObject joueur; 

    public int Vie
    {
        get => vie;
        set => vie = value;
    }
    
    void Update()
    {
        if (recolte != 0)
        {
            Game game = joueur.gameObject.GetComponent<Game>();
            game.argent += recolte;
            recolte = 0;
        }

        if (Vie < 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Villageois Allié")
        {
            Ouvrier ouvrier = other.gameObject.GetComponent<Ouvrier>();
            recolte += ouvrier.stockressource;
            ouvrier.stockressource = 0;
        }
    }
}
