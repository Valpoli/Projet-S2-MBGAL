using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boutons : MonoBehaviour
{
    public GameObject clone;

    public GameObject guerrier;
    public GameObject archer;
    public GameObject ouvrier;

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
                    cloneGame.argent -= Guerrier.prixOr / cloneGame.nbCaserne;
                    cloneGame.nourriture -= Guerrier.prixNouriture / cloneGame.nbCaserne;
                    cloneGame.popAct += Guerrier.logement;
                    Vector3 clic;
                    clic.x = 18;
                    clic.y = (float) 0.5;
                    clic.z = 14;
                    Instantiate(guerrier, clic, Quaternion.identity);
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
            Debug.Log("Construisez des casernes pour produire des unités");
        }
        else
        {
            if (cloneGame.argent >= Archer.prixOr && cloneGame.nourriture >= Archer.prixNouriture)
            {
                if (CheckPopmax(cloneGame.logementTot))
                {
                    cloneGame.argent -= Archer.prixOr / cloneGame.nbCaserne;
                    cloneGame.nourriture -= Archer.prixNouriture / cloneGame.nbCaserne;
                    cloneGame.popAct += Archer.logement;
                    Vector3 clic;
                    clic.x = 18;
                    clic.y = (float) 0.5;
                    clic.z = 14;
                    Instantiate(archer, clic, Quaternion.identity);
                }
            }
            else
            {
                Debug.Log("il vous manque des ressources");
            }
        }
    }
    
    public void instancierouvrier()
    {
        Game cloneGame = clone.GetComponent<Game>();
        if (cloneGame.nbCaserne == 0)
        {
            Debug.Log("Construisez des casernes pour produire des unités");
        }
        else
        {
            if (cloneGame.argent >= Ouvrier.prixOr && cloneGame.nourriture >= Guerrier.prixNouriture)
            {
                if (CheckPopmax(cloneGame.logementTot))
                {
                    cloneGame.argent -= Ouvrier.prixOr / cloneGame.nbCaserne;
                    cloneGame.nourriture -= Ouvrier.prixNouriture / cloneGame.nbCaserne;
                    cloneGame.popAct += Ouvrier.logement;
                    Vector3 clic;
                    clic.x = 18;
                    clic.y = (float) 0.5;
                    clic.z = 14;
                    Instantiate(ouvrier, clic, Quaternion.identity);
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
            ErrorManager.GetComponent<AfficheMessage>().MessageErreur("PopMax");
        }

        return res;
    }
    
    
}

