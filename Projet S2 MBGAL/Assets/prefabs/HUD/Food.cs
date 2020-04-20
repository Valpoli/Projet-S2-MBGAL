using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Text nbFood;
    // Start is called before the first frame update
    void Start()
    {
        nbFood.text = ": 1000";
    }

    public void actualnbFood(int Food)
    {
        nbFood.text = ": " + Food.ToString();
    }
}
