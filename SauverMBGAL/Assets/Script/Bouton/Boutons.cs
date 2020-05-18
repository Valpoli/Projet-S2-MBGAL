using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boutons : MonoBehaviour
{
    public GameObject clone;
    public GameObject unité;
    public GameObject ErrorManager;
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

    public void instancierSoldat()
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
                    cloneGame.argent -= Guerrier.prixOr / cloneGame.nbCaserne;
                    cloneGame.nourriture -= Guerrier.prixNouriture / cloneGame.nbCaserne;
                    cloneGame.popAct += Guerrier.logement;
                    Vector3 clic;
                    clic.x = 18;
                    clic.y = (float) 0.5;
                    clic.z = 14;
                    Instantiate(unité, clic, Quaternion.identity);
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

