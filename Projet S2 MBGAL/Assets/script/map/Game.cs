using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    private long score;
    private long logementTot;
    private long argent;
    private long nourriture;
    private Map map ;

    public Game(long initialMoney, long initialnourriture)
    {
        score = 0;
        logementTot = Chateau.logement;
        argent = initialMoney;
        nourriture = initialnourriture;
        map = new Map();
    }
    
    public long LogementTot()
    {
        return logementTot;
    }

    public long ArgentTot()
    {
        return argent;
    }

    public long NourritureTot()
    {
        return nourriture;
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

    public Map Map
    {
        get { return map; }
    }
}


