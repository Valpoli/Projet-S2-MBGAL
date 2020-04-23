using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gold : MonoBehaviour
{ 
    public GameObject Clone;
    public Text nbGold;

   
    // Start is called before the first frame update

    private void Update()
    {
        Game Or = Clone.GetComponent<Game>();
        nbGold.text = ": " + Convert.ToString(Or.argent);
    }
    
}
