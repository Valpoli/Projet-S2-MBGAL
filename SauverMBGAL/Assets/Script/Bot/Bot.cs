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
    public List<(GameObject,bool)> ouvriers = new List<(GameObject, bool)>();
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
        if (nbOuvrier <= 4)
        {
            GameObject unit = cloneConstr.Instancier("Ouvrier",new Vector3(75,(float) 0.5,75)).Item2;
            if (unit != null)
            {
                ouvriers.Add((unit,false));
                nbOuvrier += 1;
            }
        }
        StartCoroutine(Pause());
    }
}
