using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject test1;
    public Text nbFood;
    
    // Start is called before the first frame update

    void Update()
    {
        Game Food1 = test1.GetComponent<Game>();
        nbFood.text = ": " + Convert.ToString(Food1.nourriture);
    }
}