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
<<<<<<< HEAD:Projet S2 MBGAL/Assets/prefabs/HUD/MontreNourri2.cs
        tests.needAnInput = true;
=======
        
        tests.nourriture += 100;
        
>>>>>>> 5547740324fa43180478f361e837d3036556823a:Projet S2 MBGAL/Assets/prefabs/HUD/MontreNourri.cs
    }
  
}
