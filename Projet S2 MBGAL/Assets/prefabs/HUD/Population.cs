using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Population : MonoBehaviour
{
    public Text nbPop;

    public GameObject pop;
    // Start is called before the first frame update
    void Update()
    {
        Game Pop = pop.GetComponent<Game>();
        nbPop.text = ": " + Convert.ToString(Pop.popAct) + "/" + Convert.ToString(Pop.logementTot);
    }

    
}
