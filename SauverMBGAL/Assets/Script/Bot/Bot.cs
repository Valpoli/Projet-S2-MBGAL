using System;
using System.Collections;
using System.Collections.Generic;
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
    
    
     private void Start()
     {
         nbOuvrier = 0;
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
         yield return new WaitForSeconds(5);
         EnAction = false;
     }

    public void BotManager()
    {
        ConstructionBot cloneConstr = gameObject.GetComponent<ConstructionBot>();
        if (nbOuvrier <= 4)
        {
            cloneConstr.Instancier("Ouvrier",new Vector3(75,(float) 0.5,75));
            nbOuvrier += 1;
        }
        StartCoroutine(Pause());
    }

}
