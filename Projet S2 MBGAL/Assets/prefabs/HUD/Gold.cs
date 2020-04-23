using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public Text nbGold;

    public GameObject Or;
    // Start is called before the first frame update


    private void Update()
    {
        Game or = Or.GetComponent<Game>();
        nbGold.text = ": " + Convert.ToString(or.argent);

    }
}
