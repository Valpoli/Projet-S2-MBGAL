using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{
    public string nbPop;
    // Start is called before the first frame update
    void Start()
    {
        nbPop = "2 / 15";
    }

    public void actualnbpop(int popact, int popmax)
    {
        nbPop = popact.ToString() + " / " + popmax.ToString();
    }
}
