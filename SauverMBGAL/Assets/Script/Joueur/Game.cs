using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.UIElements;

public class Game : MonoBehaviour
{
    /// variable de la partie
    public long logementTot;
    public long popAct;
    public long argent;
    public long nourriture;
    public int nbCaserne;
    public Map map = new Map();
    private Camera cam;
    private int cameraCurrentZoom = 20;

    /// prefabs nécessaires (batiments)
    public GameObject ObjMaison;
    public GameObject ObjCaserne;
    public GameObject ObjTour;
    public GameObject ObjChamp;
    public GameObject ObjChateauA;
    public GameObject ObjChateauE;

    /// prefabs nécessaires (biome)
    public GameObject Foret;
    public GameObject Rocher;
    public GameObject Mer;
    public GameObject Mine;
    
    /// prefabs nécessaires (Message d'erreur)
    public GameObject ErrorManager;
    
    /// s'il faut construire
    public bool needMaison;
    public bool needCaserne;
    public bool needTour;
    public bool needChamp;
    public bool needDestruction;

    public Game()
    {
        needMaison = false;
        needCaserne = false;
        needTour = false;
        needChamp = false;
        needDestruction = false;
    }

    void Start()
    {
        GenerationMap();
        cam = Camera.main;
        Camera.main.orthographicSize = cameraCurrentZoom;
    }

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
        
        if (needDestruction && Input.GetMouseButtonDown(0))
        {
            Vector3 clic = cam.ScreenToWorldPoint(Input.mousePosition);
            destruction(clic);
        }
    }

    #region Maison

    public void ConstruireMaison(Vector3 clic)
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
                    ErrorManager.GetComponent<AfficheMessage>().MessageErreur("DejaBatiment");
                }
            }
            else
            {
                ErrorManager.GetComponent<AfficheMessage>().MessageErreur("ManqueArgent");
            }
        }
        else
        {
            ErrorManager.GetComponent<AfficheMessage>().MessageErreur("PasDansCarte");
        }

        needMaison = false;
    }

    public void InstantiateMaison(Vector3 clic)
    {
        clic.y = (float) 1;
        Instantiate(ObjMaison, clic, Quaternion.identity);
    }

    #endregion

    #region Caserne

    public void ConstruireCaserne(Vector3 clic)
    {
        if (Construction.DanslaCarte(clic))
        {
            (int i, int j) = Construction.posDansMatrice(Construction.calcCentre(clic));
            if (Caserne.caserne.prix <= argent)
            {
                if (map.Construire(i, j, ref argent, ref logementTot, TypeBatiment.BatimentType.CASERNE))
                {
                    InstantiateCaserne(Construction.calcCentre(clic));
                    nbCaserne += 1;
                }
                else
                {
                    ErrorManager.GetComponent<AfficheMessage>().MessageErreur("DejaBatiment");
                }
            }
            else
            {
                ErrorManager.GetComponent<AfficheMessage>().MessageErreur("ManqueArgent");
            }
        }
        else
        {
            ErrorManager.GetComponent<AfficheMessage>().MessageErreur("PasDansCarte");
        }

        needCaserne = false;
    }

    public void InstantiateCaserne(Vector3 clic)
    {
        clic.y = (float) 1;
        Instantiate(ObjCaserne, clic, Quaternion.identity);
    }

    #endregion

    #region Tour

    public void ConstruireTour(Vector3 clic)
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
                    ErrorManager.GetComponent<AfficheMessage>().MessageErreur("DejaBatiment");
                }
            }
            else
            {
                ErrorManager.GetComponent<AfficheMessage>().MessageErreur("ManqueArgent");
            }
        }
        else
        {
            ErrorManager.GetComponent<AfficheMessage>().MessageErreur("PasDansCarte");
        }

        needTour = false;
    }

    public void InstantiateTour(Vector3 clic)
    {
        clic.y = (float) 1;
        Instantiate(ObjTour, clic, Quaternion.identity);
    }

    #endregion

    #region Champ

    public void ConstruireChamp(Vector3 clic)
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
                    ErrorManager.GetComponent<AfficheMessage>().MessageErreur("DejaBatiment");
                }
            }
            else
            {
                ErrorManager.GetComponent<AfficheMessage>().MessageErreur("ManqueArgent");
            }
        }
        else
        {
            ErrorManager.GetComponent<AfficheMessage>().MessageErreur("PasDansCarte");
        }

        needChamp = false;
    }

    public void InstantiateChamp(Vector3 clic)
    {
        clic.y = (float) 0;
        Instantiate(ObjChamp, clic, Quaternion.identity);
    }

    #endregion

    #endregion
    
    #region Destruction

    public void destruction(Vector3 clic)
    {
        if (Construction.DanslaCarte(clic))
        {
            (int i, int j) = Construction.posDansMatrice(Construction.calcCentre(clic));
            if (map.matrix[i,j].Detruire())
            {
                needDestruction = false;
            }
            else
            {
                ErrorManager.GetComponent<AfficheMessage>().MessageErreur("RienADetruire");
            }
        }
        else
        {
            ErrorManager.GetComponent<AfficheMessage>().MessageErreur("RienADetruire");
        }
        needDestruction = false;
    }
    #endregion

    #region Generation
    public void GenerationMap()
    {
        int x;
        int y;
        (int, int)[] listArb =
        {
            (0, 0), (1, 0), (2, 0), (3, 0), (4, 0), (5, 0), (6, 0), (6, 1), (0, 1), (0, 2), (0, 3), (18, 0), (19, 0),
            (20, 0), (21, 0), (22, 0), (23, 0), (24, 0), (21, 1), (22, 1), (23, 1), (24, 1), (21, 2), (22, 2), (23, 2),
            (24, 2), (22, 3), (23, 3), (24, 3), (24, 4), (24, 5), (24, 6), (12, 4), (13, 4), (12, 5), (13, 5), (0, 11),
            (0, 12), (0, 13), (1, 11), (1, 12), (1, 13), (0, 20), (0, 21), (0, 22), (0, 23), (0, 24), (1, 24), (2, 24),
            (3, 24), (4, 24), (11, 24), (12, 24), (13, 24), (11, 23), (12, 23), (13, 23), (21, 24), (22, 24), (23, 24),
            (24, 24), (24, 23), (24, 22), (24, 21), (24, 20), (24, 19), (24, 18), (23, 18), (19, 11), (20, 11), (19, 12), (20, 12)
        };
        int nbArb = listArb.Length;
        for (int i = 0; i < nbArb; i++)
        {
            (x, y) = listArb[i];
            map.matrix[x, y] = new Case(Case.Biome.BOIS);
            Instantiate(Foret, Construction.posSurlaMap(x, y), Quaternion.identity);
        }

        (int, int)[] listRocher =
        {
            (10, 15), (9, 14), (10, 14), (0, 14), (0, 15), (0, 16), (0, 17), (0, 18), (0, 19), (1, 14), (1, 15),
            (1, 16), (1, 17), (1, 18), (1, 19), (3, 14), (4, 14), (5, 14), (6, 14), (7, 14), (8, 14), (3, 15), (4, 15),
            (5, 15), (6, 15), (7, 15), (8, 15),
            (9, 15), (3, 16), (4, 16), (5, 16), (6, 16), (7, 16), (8, 16), (9, 16), (10, 16), (3, 17), (4, 17), (5, 17),
            (6, 17), (7, 17), (8, 17), (9, 17), (10, 17), (3, 18), (4, 18), (5, 18), (6, 18), (7, 18), (8, 18), (9, 18),
            (10, 18), (3, 19), (4, 19), (5, 19), (6, 19), (7, 19), (8, 19), (9, 19), (10, 19), (5, 20), (6, 20),
            (7, 20), (8, 20), (9, 20), (10, 20), (5, 21), (6, 21), (7, 21), (8, 21), (9, 21), (10, 21), (5, 23),
            (6, 23), (7, 23), (8, 23), (9, 23), (10, 23), (5, 24), (6, 24), (7, 24), (8, 24), (9, 24), (10, 24)
        };
        
        int nbRocher = listRocher.Length;
        for (int j = 0; j < nbRocher; j++)
        {
            (x, y) = listRocher[j];
            map.matrix[x, y] = new Case(Case.Biome.MONTAGNE);
            Instantiate(Rocher, Construction.posSurlaMap(x, y), Quaternion.identity);
        }

        (int, int)[] listMer =
        {
            (11, 14), (10, 13), (11, 13), (12, 13), (11, 12), (12, 12), (13, 12), (12, 11),
            (13, 11), (14, 11), (13, 10), (14, 10), (15, 10), (14, 9), (15, 9), (16, 9), (15, 8), (16, 8), (17, 8),
            (16, 7), (17, 7), (19, 5), (20, 5), (19, 4), (20, 4), (21, 4), (20, 3), (21, 3), (10, 6), (11, 6), (10, 5),
            (11, 5), (18, 13), (19, 13), (18, 14), (19, 14)
        };
        int nbEau = listMer.Length;
        for (int j = 0; j < nbEau; j++)
        {
            (x, y) = listMer[j];
            map.matrix[x, y] = new Case(Case.Biome.MER);
            Instantiate(Mer, Construction.posSurlaMap(x, y), Quaternion.identity);
        }

        (int, int)[] listMine =
        {
            (1, 23), (2, 23), (1, 22), (2, 22), (19, 1), (20, 1), (19, 2), (20, 2), (22, 4), (23, 4), (22, 5), (23, 5)
        };
        int nbMine = listMine.Length;
        for (int j = 0; j < nbMine; j++)
        {
            (x, y) = listMine[j];
            map.matrix[x, y] = new Case(Case.Biome.MINE);
            Instantiate(Mine, Construction.posSurlaMap(x, y), Quaternion.identity);
        }
        
        (int, int)[] listChateau =
        {
            (2,2), (3,2), (2,3), (3,3),(22,22), (21,22), (22,21), (21,21),(4,3), (5,3), (4,2), (5,2),(20,22), (19,22), (20,21), (19,21)
        };
        int nbChateau = listChateau.Length;
        for (int j = 0; j < nbChateau; j++)
        {
            (x, y) = listChateau[j];
            map.Construire(x, y, ref argent, ref logementTot, TypeBatiment.BatimentType.CHATEAU);
        }
        Vector3 ChateauA = new Vector3(12,1,12);
        Vector3 ChateauE = new Vector3(88,1,88);
        Instantiate(ObjChateauA, ChateauA, Quaternion.identity);
        Instantiate(ObjChateauE, ChateauE, Quaternion.identity);
        
    }
    #endregion
}