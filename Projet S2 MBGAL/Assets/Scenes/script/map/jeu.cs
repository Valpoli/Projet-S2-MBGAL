using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{
    private long score;
    private long logementTot;
    private long argent;
    private long nourriture;
    private Carte carte;

    public Jeu(long initialMoney, long initialnourriture)
    {
        score = 0;
        logementTot = Chateau.logement;
        argent = initialMoney;
        nourriture = initialnourriture;
        carte = new Carte();
    }

    public long Argent
    {
        get { return argent; }
    }
    
    public long Score
    {
        get { return score; }
    }
    
    public long Nourriture
    {
        get { return nourriture; }
    }

    public Carte Carte
    {
        get { return new Carte(); }
    }
}

