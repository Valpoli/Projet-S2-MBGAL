using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boutons : MonoBehaviour
{
    public GameObject clone;
    public GameObject unité;
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
            Debug.Log("Construisez des casernes pour produire des unités");
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
                    Debug.Log(clic);
                    Instantiate(unité, clic, Quaternion.identity);
                }
            }
            else
            {
                Debug.Log("il vous manque des ressources");
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
            Debug.Log("population maximum atteinte");
        }

        return res;
    }
    
    
}
