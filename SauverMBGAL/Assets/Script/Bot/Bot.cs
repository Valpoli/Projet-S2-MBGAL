using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bot : MonoBehaviour
{
    /// variable du bot
    public bool EnAction;
    public long logementTot;
    public long popAct;
    public long argent;
    public long nourriture;
    public int nbOuvrier;
    public int nbBoisDetruit;

    /// pour decision
    public bool needNourriture;
    public bool needArgent;
    public bool needPopmax;
    public int nbDansWave;
    public bool Charger;
    
     private void Start()
     {
         nbOuvrier = 0;
         nbBoisDetruit = 0;
         EnAction = false;
         needNourriture = false; 
         needArgent = false; 
         needPopmax = false;;
     }

     private void Update()
     {
         if (!EnAction)
         {
             Debug.Log("hophop");
             EnAction = true;
             BotManager();
         }
     }

     IEnumerator Pause()
     {
         yield return new WaitForSeconds(3);
         EnAction = false;
     }

    public void BotManager()
    {
        ConstructionBot cloneConstr = gameObject.GetComponent<ConstructionBot>();
        if (Charger)
        {
            Charger = false;
        }
        if (nbOuvrier < 3)
        {
            int place = cloneConstr.CheckPos("Ouvrier");
            Vector3 posi = new Vector3((float)cloneConstr.pointSpawnOuvrier[place].Item1,(float)0.5,(float)cloneConstr.pointSpawnOuvrier[place].Item2);
            GameObject unit = cloneConstr.Instancier("Ouvrier",posi).Item2;
            if (unit != null)
            {
                nbOuvrier += 1;
            }
        }

        else if (needArgent)
        {
            
        }
        else if (needNourriture)
        {
            
        }
        else if (needPopmax)
        {
            
        }
        else
        {
            if (nbDansWave >= 8)
            {
                nbDansWave = 0;
                Charger = true;
                cloneConstr.emplacementLibreSoldat = new List<bool>{false,false,false,false,false};
            }
            chargerWave();
        }
        StartCoroutine(Pause());
    }

    public void chargerWave()
    {
        ConstructionBot cloneConstr = gameObject.GetComponent<ConstructionBot>();
        int place = cloneConstr.CheckPos("Guerrier");
        Vector3 pos = new Vector3((float)cloneConstr.pointSpawnSoldat[place].Item1,(float)0.5,(float)cloneConstr.pointSpawnSoldat[place].Item2);
        cloneConstr.emplacementLibreSoldat[place] = true;
        if (nbDansWave < 4)
        {
            cloneConstr.Instancier("Archer", pos);
        }
        else
        {
            cloneConstr.Instancier("Guerrier", pos);
        }
        nbDansWave += 1;
    }
    
}
