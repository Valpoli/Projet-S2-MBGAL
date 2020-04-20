using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Population : MonoBehaviour
{
    public Text nbPop;
    // Start is called before the first frame update
    void Start()
    {
        nbPop.text = "2 / 15";
    }

    public void actualnbpop(int popact, int popmax)
    {
        nbPop.text = popact.ToString() + " / " + popmax.ToString();
    }
}
