using System;
using System.Collections.Generic;
using UnityEngine;
public class Boutons : MonoBehaviour
{
    public GameObject clone;
    public GameObject guerrier;
    public GameObject archer;
    public GameObject ouvrier;
    public GameObject ErrorManager;
    public List<(int,int)> pointSpawn;
    public List<bool> emplacementLibre;

    private void Start()
    {
        pointSpawn = new List<(int, int)>{(17,9),(17,12),(17,15),(20,9),(20,12),(20,15),(23,9),(23,12),(23,15)};
        emplacementLibre = new List<bool>{false,false,false,false,false,false,false,false,false};
    }

    public void ConstrMaison()
    {
        Game cloneGame = clone.GetComponent<Game>();
        cloneGame.needMaison = true;
    }
    public void ConstrCaserne()
    {
        Game cloneGame = clone.GetComponent<Game>();
        cloneGame.needCaserne = true;
    }
    public void ConstrChamp()
    {
        Game cloneGame = clone.GetComponent<Game>();
        cloneGame.needChamp = true;
    }
    public void ConstrTour()
    {
        Game cloneGame = clone.GetComponent<Game>();
        cloneGame.needTour = true;
    }
    public void DetruireBat()
    {
        Game cloneGame = clone.GetComponent<Game>();
        cloneGame.needDestruction = true;
    }

    public bool placeDispo()
    {
        bool res = (!emplacementLibre[0] || !emplacementLibre[1] || !emplacementLibre[2] || !emplacementLibre[3] || !emplacementLibre[4] || !emplacementLibre[5] || !emplacementLibre[6] || !emplacementLibre[7] || !emplacementLibre[8]);
        return res;
    }
    public int CheckPos()
    {
        int res = 0;
        bool trouve = false;
        while (res < 9 && !trouve)
        {
            if (emplacementLibre[res])
            {
                res += 1;
            }
            else
            {
                trouve = true;
            }
        }
        return res;
    }
    public void instancierGuerrier()
    {
        Game cloneGame = clone.GetComponent<Game>();
        if (cloneGame.nbCaserne == 0)
        {
            ErrorManager.GetComponent<AfficheMessage>().MessageErreur("PasDeCaserne");
        }
        else
        {
            if (cloneGame.argent >= Guerrier.prixOr && cloneGame.nourriture >= Guerrier.prixNouriture)
            {
                if (CheckPopmax(cloneGame.logementTot))
                {
                    if (placeDispo())
                    {
                        cloneGame.argent -= Guerrier.prixOr / cloneGame.nbCaserne;
                        cloneGame.nourriture -= Guerrier.prixNouriture / cloneGame.nbCaserne;
                        cloneGame.popAct += Guerrier.logement;
                        int pos = CheckPos();
                        float x = (float) pointSpawn[pos].Item1;
                        float z = (float) pointSpawn[pos].Item2;
                        float y = (float) 0.5;
                        emplacementLibre[pos] = true;
                        Vector3 clic = new Vector3(x,y,z);
                        Instantiate(guerrier, clic, Quaternion.identity);
                    }
                    else
                    {
                        ErrorManager.GetComponent<AfficheMessage>().MessageErreur("BougerTroupe");
                    }
                }
            }
            else
            {
                ErrorManager.GetComponent<AfficheMessage>().MessageErreur("ManqueNourriture");
            }
        }
    }
    
    public void instancierArcher()
    {
        Game cloneGame = clone.GetComponent<Game>();
        if (cloneGame.nbCaserne == 0)
        {
            ErrorManager.GetComponent<AfficheMessage>().MessageErreur("PasDeCaserne");
        }
        else
        {
            if (cloneGame.argent >= Guerrier.prixOr && cloneGame.nourriture >= Guerrier.prixNouriture)
            {
                if (CheckPopmax(cloneGame.logementTot))
                {
                    if (placeDispo())
                    {
                        cloneGame.argent -= Guerrier.prixOr / cloneGame.nbCaserne;
                        cloneGame.nourriture -= Guerrier.prixNouriture / cloneGame.nbCaserne;
                        cloneGame.popAct += Guerrier.logement;
                        int pos = CheckPos();
                        float x = (float) pointSpawn[pos].Item1;
                        float z = (float) pointSpawn[pos].Item2;
                        float y = (float) 0.5;
                        emplacementLibre[pos] = true;
                        Vector3 clic = new Vector3(x,y,z);
                        Instantiate(archer, clic, Quaternion.identity);
                    }
                    else
                    {
                        ErrorManager.GetComponent<AfficheMessage>().MessageErreur("BougerTroupe");
                    }
                }
            }
            else
            {
                ErrorManager.GetComponent<AfficheMessage>().MessageErreur("ManqueNourriture");
            }
        }
    }
    
    public void instancierouvrier()
    {
        Game cloneGame = clone.GetComponent<Game>();
        if (cloneGame.nbCaserne == 0)
        {
            ErrorManager.GetComponent<AfficheMessage>().MessageErreur("PasDeCaserne");
        }
        else
        {
            if (cloneGame.argent >= Guerrier.prixOr && cloneGame.nourriture >= Guerrier.prixNouriture)
            {
                if (CheckPopmax(cloneGame.logementTot))
                {
                    if (placeDispo())
                    {
                        cloneGame.argent -= Guerrier.prixOr / cloneGame.nbCaserne;
                        cloneGame.nourriture -= Guerrier.prixNouriture / cloneGame.nbCaserne;
                        cloneGame.popAct += Guerrier.logement;
                        int pos = CheckPos();
                        float x = (float) pointSpawn[pos].Item1;
                        float z = (float) pointSpawn[pos].Item2;
                        float y = (float) 0.5;
                        emplacementLibre[pos] = true;
                        Vector3 clic = new Vector3(x,y,z);
                        Instantiate(ouvrier, clic, Quaternion.identity);
                    }
                    else
                    {
                        ErrorManager.GetComponent<AfficheMessage>().MessageErreur("BougerTroupe");
                    }
                }
            }
            else
            {
                ErrorManager.GetComponent<AfficheMessage>().MessageErreur("ManqueNourriture");
            }
        }
    }

    public bool CheckPopmax(long logementTot)
    {
        bool res = false;
        Game cloneGame = clone.GetComponent<Game>();
        if (cloneGame.popAct < cloneGame.logementTot)
        {
            res = true;
        }
        else
        {
            ErrorManager.GetComponent<AfficheMessage>().MessageErreur("PopMax");
        }
        return res;
    }
}

