using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionBot : MonoBehaviour
{
    public GameObject clonePlayer;
    public GameObject MaisonE;
    public GameObject CaserneE;
    public GameObject TourE;
    public GameObject ChampE;
    public GameObject GuerrierE;
    public GameObject ArcherE;
    public GameObject OuvrierE;
    public List<(int,int)> pointSpawnSoldat;
    public List<bool> emplacementLibreSoldat;
    public List<(double,double)> pointSpawnOuvrier;
    public List<bool> emplacementLibreOuvrier;
    public List<(int,int)> pointSpawnMetC;
    public List<bool> emplacementLibreMetC;
    public List<(int,int)> pointSpawnTour;
    public List<bool> emplacementLibreTour;
    public List<(int,int)> pointSpawnChamp;
    public List<bool> emplacementLibreChamp;
    public List<(double,double)> pointDeplacementArmee;
    public List<(int,int)> listArbre;

    private void Start()
    {
        pointSpawnSoldat = new List<(int,int)>{(85,83),(88,83),(91,83),(85,80),(88,80),(91,80),(85,77),(88,77),(91,77)};
        emplacementLibreSoldat = new List<bool>{false,false,false,false,false,false,false,false,false};
        pointSpawnOuvrier = new List<(double,double)>{(93.5,85),(93.5,88),(93.5,91),(95,86.5),(95,89.5)};
        emplacementLibreOuvrier = new List<bool>{false,false,false,false,false};
        pointSpawnMetC = new List<(int,int)>{(19,21),(19,20),(19,19),(18,21),(18,20),(18,19),(17,21),(17,20),(17,19),(16,21),(16,20),(16,19),(15,21),(15,20),(15,19),(14,21),(14,20),(14,19)};
        emplacementLibreMetC = new List<bool>{false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false}; 
        pointSpawnTour = new List<(int, int)>{(20,18),(20,23)}; 
        emplacementLibreTour = new List<bool>{false,false}; 
        pointSpawnChamp = new List<(int, int)>{(23,21),(23,22),(23,23),(22,23),(21,23)}; 
        emplacementLibreChamp = new List<bool>{false,false,false,false,false};
        listArbre = new List<(int, int)>{(23,18),(24,21),(24,20),(24,22),(24,18),(24,19),(23,24),(23,24),(22,24),(21,24),(24,24)};
    }
    
    public int CheckPos(string element)
    {
        int res = 0;
        bool trouve = false;
        if (element == "Guerrier")
        {
            while (res < emplacementLibreSoldat.Count && !trouve)
            {
                if (emplacementLibreSoldat[res])
                {
                    res += 1;
                }
                else
                {
                    trouve = true;
                }
            }
        }
        if (element == "Archer")
        {
            while (res < emplacementLibreSoldat.Count && !trouve)
            {
                if (emplacementLibreSoldat[res])
                {
                    res += 1;
                }
                else
                {
                    trouve = true;
                }
            }
        }
        if (element == "Ouvrier")
        {
            while (res < emplacementLibreOuvrier.Count && !trouve)
            {
                if (emplacementLibreOuvrier[res])
                {
                    res += 1;
                }
                else
                {
                    trouve = true;
                }
            }
        }
        if (element == "MetC")
        {
            while (res < emplacementLibreMetC.Count && !trouve)
            {
                if (emplacementLibreMetC[res])
                {
                    res += 1;
                }
                else
                {
                    trouve = true;
                }
            }
        }
        if (element == "Tour")
        {
            while (res < emplacementLibreTour.Count && !trouve)
            {
                if (emplacementLibreTour[res])
                {
                    res += 1;
                }
                else
                {
                    trouve = true;
                }
            }
        }
        if (element == "Champ")
        {
            while (res < emplacementLibreChamp.Count && !trouve)
            {
                if (emplacementLibreChamp[res])
                {
                    res += 1;
                }
                else
                {
                    trouve = true;
                }
            }
        }
        return res;
    }
    
    #region Construction
    public bool Construire((int, int) coord, string batiment)
    {
        bool res = true;
        Game clonePartie = clonePlayer.GetComponent<Game>();
        Bot cloneBot = gameObject.GetComponent<Bot>();
        Case[,] cloneMatrice = clonePartie.map.matrix;
        if (batiment == "Maison")
        {
            if (cloneBot.argent < Maison.maison.prix)
            {
                cloneBot.argent -= Maison.maison.prix;
                Vector3 clic = new Vector3(coord.Item1,1,coord.Item2);
                Instantiate(MaisonE, clic, Quaternion.identity);
            }
            else
            {
                res = false;
            }
        }
        if (batiment == "Caserne")
        {
            if (cloneBot.argent < Caserne.caserne.prix)
            {
                cloneBot.argent -= Caserne.caserne.prix;
                Vector3 clic = new Vector3(coord.Item1,1,coord.Item2);
                Instantiate(CaserneE, clic, Quaternion.identity);
            }
            else
            {
                res = false;
            }
        }
        if (batiment == "Tour")
        {
            if (cloneBot.argent < Tour.tour.prix)
            {
                cloneBot.argent -= Tour.tour.prix;
                Vector3 clic = new Vector3(coord.Item1,1,coord.Item2);
                Instantiate(TourE, clic, Quaternion.identity);
            }
            else
            {
                res = false;
            }
        }
        if (batiment == "Champ")
        {
            if (cloneBot.argent < Champ.champ.prix)
            {
                cloneBot.argent -= Champ.champ.prix;
                Vector3 clic = new Vector3(coord.Item1,0,coord.Item2);
                Instantiate(ChampE, clic, Quaternion.identity);
            }
            else
            {
                res = false;
            }
        }
        return res;
    }
    #endregion
    
    #region Instancer Unité
    
    public bool CheckPopmax(long logementTot)
    {
        bool res = false;
        Bot cloneBot = gameObject.GetComponent<Bot>();
        if (cloneBot.popAct < cloneBot.logementTot)
        {
            res = true;
        }
        return res;
    }

    public (bool,GameObject) Instancier(string unite, Vector3 endroit)
    {
        bool res = true;
        GameObject perso = null;
        Bot cloneBot = gameObject.GetComponent<Bot>();
        if (CheckPopmax(cloneBot.logementTot))
        {
            if (unite == "Guerrier")
            {
                if (cloneBot.argent >= Guerrier.prixOr && cloneBot.nourriture >= Guerrier.prixNouriture)
                {
                    cloneBot.argent -= Guerrier.prixOr;
                    cloneBot.nourriture -= Guerrier.prixNouriture;
                    perso = Instantiate(GuerrierE, endroit, Quaternion.identity);
                }
                else
                {
                    res = false;
                }
            }
            if (unite == "Archer")
            {
                if (cloneBot.argent >= Archer.prixOr && cloneBot.nourriture >= Archer.prixNouriture)
                {
                    cloneBot.argent -= Archer.prixOr;
                    cloneBot.nourriture -= Archer.prixNouriture;
                    perso = Instantiate(ArcherE, endroit, Quaternion.identity);
                }
                else
                {
                    res = false;
                }
            }
            if (unite == "Ouvrier")
            {
                if (cloneBot.argent >= Ouvrier.prixOr && cloneBot.nourriture >= Ouvrier.prixNouriture)
                {
                    cloneBot.argent -= Ouvrier.prixOr;
                    cloneBot.nourriture -= Ouvrier.prixNouriture;
                    perso = Instantiate(OuvrierE, endroit, Quaternion.identity);
                }
                else
                {
                    res = false;
                }
            }
        }
        else
        {
            res = false;
        }
        return (res,perso);
    }

    #endregion
}
