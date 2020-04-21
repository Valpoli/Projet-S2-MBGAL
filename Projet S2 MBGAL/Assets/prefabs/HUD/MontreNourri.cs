using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontreNourri : MonoBehaviour
{
    public GameObject test;
    public GameObject test1;
    public void Bonjours()
    {
        Camera cam = Camera.main;
        Game tests = test.GetComponent<Game>();
        
        tests.nourriture += 100;
        
    }
  
}
