using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonjour : MonoBehaviour
{
    public GameObject test;
    public void Bonjours()
    {
        Debug.Log(test.GetComponent<int>());
    }
  
}
