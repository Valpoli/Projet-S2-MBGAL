using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bot : MonoBehaviour
{
    /// variable du bot
    public int speed = 5;
    public bool EnAction;
    public long logementTot;
    public long popAct;
    public long argent;
    public long nourriture;
    public int nbOuvrier;
    public int nbBoisDetruit;
    public List<GameObject> guerrier;
    public List<GameObject> archers;
    
     private void Start()
     {
         nbOuvrier = 0;
         nbBoisDetruit = 0;
         EnAction = false;
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
        if (nbOuvrier < 5)
        {
            int place = cloneConstr.CheckPos("Ouvrier");
            Debug.Log(place);
            Debug.Log(nbOuvrier);
            Debug.Log(cloneConstr.emplacementLibreOuvrier[place]);
            cloneConstr.emplacementLibreOuvrier[place] = true;
            Vector3 posi = new Vector3((float)cloneConstr.pointSpawnOuvrier[place].Item1,(float)0.5,(float)cloneConstr.pointSpawnOuvrier[place].Item2);
            GameObject unit = cloneConstr.Instancier("Ouvrier",posi).Item2;
            if (unit != null)
            {
                nbOuvrier += 1;
            }
        }
        StartCoroutine(Pause());
    }
}
