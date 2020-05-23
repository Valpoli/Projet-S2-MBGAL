using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    /// prefabs nécessaires (batiments)
    public GameObject joueur;
    public GameObject Guerrier;

    public GameObject ObjMaison;
    public GameObject ObjCaserne;
    public GameObject ObjTour;
    public GameObject ObjChamp;
    public GameObject ObjChateau;

    public long logementTot;
    public long popAct;
    public long argent;
    public int nbCaserne;
    public bool IsAttacked;
    public bool pasAssezor;
    public bool pasAsseznourri;
    public bool pasAssezpopmax;
    /// variable pour intelligence bot
     public int nbSoldat;
     public int nbVillageois;
     public int nbOuvrier;
     List<bool> Position = new List<bool> { false, false, false, false, false,false};
     List<(int,int)> PositionPossible = new List<(int, int)>{(1,1),(1,1),(1,1),(1,1),(1,1),(1,1)};
     List<(int,int)> itineraire = new List<(int, int)>{(1,1),(1,1),(1,1),(1,1),(1,1),(1,1)};
     public int wave;
     public bool formationEnAttaque;
    private void Update()
    {
        throw new NotImplementedException();
    }

    public void BotManager()
    {
        if (nbSoldat <= 6)
        {
            if (placeDispo())
            {
                int pos = CheckPos();
                Vector3 posit = new Vector3((float)PositionPossible[pos].Item1,(float)0.5,(float)PositionPossible[pos].Item2);
                Instantiate(Guerrier, posit, Quaternion.identity);
                nbSoldat += 1;
            }
        }
    }

    public bool placeDispo()
    {
        bool res = (!Position[0] || !Position[1] || !Position[2] || !Position[3] || !Position[4] || !Position[5]);
        return res;
    }

    public int CheckPos()
    {
        int res = 0;
        bool trouve = false;
        while (res < 6 && !trouve)
        {
            if (Position[res])
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
    
}
