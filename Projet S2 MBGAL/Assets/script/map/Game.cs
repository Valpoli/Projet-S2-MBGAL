using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Game : MonoBehaviour
{
    public long score;
    public long logementTot;
    public long argent;
    public long nourriture;
    public Map map = new Map();
    private Camera cam;
    private int cameraCurrentZoom = 15;
    
    /// prefabs nécessaires
    public GameObject Maison;
    public GameObject Caserne;
    public GameObject Tour;
    public GameObject Champ;
    
    
    /// si il faut un construire
    public bool needMaison;
    public bool needCaserne;
    public bool needTour;
    public bool needChamp;

    public Game()
    {
        needMaison = false;
        needCaserne = false;
        needTour = false;
        needChamp = false;
    }
    void Start()
    {
        cam = Camera.main;
        Camera.main.orthographicSize = cameraCurrentZoom;
    }

    // Update is called once per frame
    void Update()
    {
        BeginConstruction();
    }

    
    #region Construction 
    public void BeginConstruction()
    {
        if (needMaison && Input.GetMouseButtonDown(0))
        {
            Vector3 clic = cam.ScreenToWorldPoint(Input.mousePosition);
            ConstruireMaison(clic);
        }
    }
    #region Maison
    public void ConstruireMaison(Vector3 clic)
    {
        if (Construction.DanslaCarte(clic))
        {
            InstantiateMaison(Construction.calcCentre(clic));
        }
        else
        {
            Debug.Log("Pas dans la carte");
        }
        needMaison = false;
        (int i, int j) = Construction.posDansMatrice(Construction.calcCentre(clic));
        Debug.Log(map.Construire(i, j, ref argent, ref logementTot, TypeBatiment.BatimentType.MAISON));
    }
    
    public void InstantiateMaison(Vector3 clic)
    {
        clic.y = (float)0.5;
        Instantiate(Maison, clic, Quaternion.identity);
    }
    #endregion
    #endregion
}


