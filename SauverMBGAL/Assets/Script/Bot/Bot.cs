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

    /// pour decision
    public bool needNourriture;
    public bool needArgent;
    public bool Charger;
    public bool needPopmax;
    public int nbDansWave;
    public int nbCaserne = 0;
    public int nbChamp = 0;
    public int nbTour = 0;
    
     private void Start()
     {
         nbOuvrier = 0;
         EnAction = false;
         needNourriture = false; 
         needArgent = true; 
         needPopmax = false;
     }

     private void Update()
     {
         if (!EnAction)
         {
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
        else if (needPopmax)
        {
            int place = cloneConstr.CheckPos("MetC");
            cloneConstr.emplacementLibreMetC[place] = true;
            Vector3 pos = Construction.posSurlaMap(cloneConstr.pointSpawnMetC[place].Item1,
                cloneConstr.pointSpawnMetC[place].Item2); 
            cloneConstr.Construire(((int)pos.x,(int)pos.z), "Maison");
            needPopmax = false;
        }
        else if (nbCaserne == 0)
        {
            int place = cloneConstr.CheckPos("MetC");
            cloneConstr.emplacementLibreMetC[place] = true;
            Vector3 pos = Construction.posSurlaMap(cloneConstr.pointSpawnMetC[place].Item1,
                cloneConstr.pointSpawnMetC[place].Item2); 
            cloneConstr.Construire(((int)pos.x,(int)pos.z), "Caserne");
            nbCaserne += 1;
        }
        else if (nbTour<2 && argent > 2000)
        {
            int place = cloneConstr.CheckPos("Tour");
            cloneConstr.emplacementLibreTour[place] = true;
            Vector3 pos = Construction.posSurlaMap(cloneConstr.pointSpawnTour[place].Item1,
                cloneConstr.pointSpawnTour[place].Item2); 
            cloneConstr.Construire(((int)pos.x,(int)pos.z),"Tour");
            nbTour += 1;
        }
        else if (nbTour >= 2 && nbChamp < 5)
        {
            int place = cloneConstr.CheckPos("Champ");
            cloneConstr.emplacementLibreChamp[place] = true;
            Vector3 pos = Construction.posSurlaMap(cloneConstr.pointSpawnChamp[place].Item1,
                cloneConstr.pointSpawnChamp[place].Item2); 
            cloneConstr.Construire(((int)pos.x,(int)pos.z),"Champ");
            nbChamp += 1;
        }
        else if (popAct <= 33)
        {
            if (nbDansWave >= 9)
            {
                nbDansWave = 0;
                Charger = true;
                cloneConstr.emplacementLibreSoldat = new List<bool>{false,false,false,false,false,false,false,false,false};
            }
            else
            {
               int result =  chargerWave();
               if (result == 1)
               {
                   needPopmax = true;
               }
               if (result == 2)
               {
                   needNourriture = false;
                   needArgent = true;
               }
               if (result == 3)
               {
                   needArgent = false;
                   needNourriture = true;
               }
            }
        }
        StartCoroutine(Pause());
    }

    public int chargerWave()
    {
        int res = 0;
        ConstructionBot cloneConstr = gameObject.GetComponent<ConstructionBot>();
        int place = cloneConstr.CheckPos("Guerrier");
        Vector3 pos = new Vector3((float)cloneConstr.pointSpawnSoldat[place].Item1,(float)0.5,(float)cloneConstr.pointSpawnSoldat[place].Item2);
        if (nbDansWave < 4)
        {
            res = cloneConstr.Instancier("Archer", pos).Item1;
            if (res == 0)
            {
                cloneConstr.emplacementLibreSoldat[place] = true;
                nbDansWave += 1;
            }
        }
        else
        {
            res = cloneConstr.Instancier("Guerrier", pos).Item1;
            if (res == 0)
            {
                cloneConstr.emplacementLibreSoldat[place] = true;
                nbDansWave += 1;
            }
        }
        
        return res;
    }
    
}
