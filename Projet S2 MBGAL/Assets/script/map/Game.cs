using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Game : MonoBehaviour
{
    public long score;
    public long logementTot;
    public long popAct;
    public long argent;
    public long nourriture;
    public Map map = new Map();
    private Camera cam;
    private int cameraCurrentZoom = 15;
    
    /// prefabs nécessaires
    public GameObject ObjMaison;
    public GameObject ObjCaserne;
    public GameObject ObjTour;
    public GameObject ObjChamp;
    
    
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
        if (needCaserne && Input.GetMouseButtonDown(0))
        {
            Vector3 clic = cam.ScreenToWorldPoint(Input.mousePosition);
            ConstruireCaserne(clic);
        }
        if (needTour && Input.GetMouseButtonDown(0))
        {
            Vector3 clic = cam.ScreenToWorldPoint(Input.mousePosition);
            ConstruireTour(clic);
        }
        if (needChamp && Input.GetMouseButtonDown(0))
        {
            Vector3 clic = cam.ScreenToWorldPoint(Input.mousePosition);
            ConstruireChamp(clic);
        }
    }
    #region Maison
    public void ConstruireMaison(Vector3 clic)
    {
        if (Construction.DansleChateau(clic))
        {
            if (Construction.DanslaCarte(clic))
            {
                (int i, int j) = Construction.posDansMatrice(Construction.calcCentre(clic));
                if (Maison.maison.prix <= argent)
                {
                    if (map.Construire(i, j, ref argent, ref logementTot, TypeBatiment.BatimentType.MAISON))
                    {
                        InstantiateMaison(Construction.calcCentre(clic));
                    }
                    else
                    {
                        Debug.Log("Il y a déjà un batiment à cet endroit");
                    }
                }
                else
                {
                    Debug.Log("Il manque de l'argent");
                }
            }
            else
            {
                Debug.Log("Pas dans la carte");
            }
        }
        else
        {
            Debug.Log("Il ne faut pas construire dans le chateau");
        }
        needMaison = false;

    }
    
    public void InstantiateMaison(Vector3 clic)
    {
        clic.y = (float)0.5;
        Instantiate(ObjMaison, clic, Quaternion.identity);
    }
    #endregion
    #region Caserne
    public void ConstruireCaserne(Vector3 clic)
    {
        if (Construction.DansleChateau(clic))
        {
            if (Construction.DanslaCarte(clic))
            {
                (int i, int j) = Construction.posDansMatrice(Construction.calcCentre(clic));
                if (Caserne.caserne.prix <= argent)
                {
                    if (map.Construire(i, j, ref argent, ref logementTot, TypeBatiment.BatimentType.CASERNE))
                    {
                        InstantiateCaserne(Construction.calcCentre(clic));
                    }
                    else
                    {
                        Debug.Log("Il y a déjà un batiment à cet endroit");
                    }
                }
                else
                {
                    Debug.Log("Il manque de l'argent");
                }
            }
            else
            {
                Debug.Log("Pas dans la carte");
            }
        }
        else
        {
            Debug.Log("Il ne faut pas construire dans le chateau");
        }

        needCaserne = false;

    }
    
    public void InstantiateCaserne(Vector3 clic)
    {
        clic.y = (float)0.5;
        Instantiate(ObjCaserne, clic, Quaternion.identity);
    }
    #endregion
    #region Tour
    public void ConstruireTour(Vector3 clic)
    {
        if (Construction.DansleChateau(clic))
        {
            if (Construction.DanslaCarte(clic))
            {
                (int i, int j) = Construction.posDansMatrice(Construction.calcCentre(clic));
                if (Tour.tour.prix <= argent)
                {
                    if (map.Construire(i, j, ref argent, ref logementTot, TypeBatiment.BatimentType.TOUR))
                    {
                        InstantiateTour(Construction.calcCentre(clic));
                    }
                    else
                    {
                        Debug.Log("Il y a déjà un batiment à cet endroit");
                    }
                }
                else
                {
                    Debug.Log("Il manque de l'argent");
                }
            }
            else
            {
                Debug.Log("Pas dans la carte");
            }
        }
        else
        {
            Debug.Log("Il ne faut pas construire dans le chateau");
        }
        needTour = false;

    }
    
    public void InstantiateTour(Vector3 clic)
    {
        clic.y = (float)0.5;
        Instantiate(ObjTour, clic, Quaternion.identity);
    }
    #endregion
    #region Champ
    public void ConstruireChamp(Vector3 clic)
    {
        if (Construction.DansleChateau(clic))
        {
            if (Construction.DanslaCarte(clic))
            {
                (int i, int j) = Construction.posDansMatrice(Construction.calcCentre(clic));
                if (Champ.champ.prix <= argent)
                {
                    if (map.Construire(i, j, ref argent, ref logementTot, TypeBatiment.BatimentType.CHAMP))
                    {
                        InstantiateChamp(Construction.calcCentre(clic));
                    }
                    else
                    {
                        Debug.Log("Il y a déjà un batiment à cet endroit");
                    }
                }
                else
                {
                    Debug.Log("Il manque de l'argent");
                }
            }
            else
            {
                Debug.Log("Pas dans la carte");
            }
        }
        else
        {
            Debug.Log("Il ne faut pas construire dans le chateau");
        }

        needChamp = false;

    }
    
    public void InstantiateChamp(Vector3 clic)
    {
        clic.y = (float)0;
        Instantiate(ObjChamp, clic, Quaternion.identity);
    }
    #endregion
    #endregion
}


