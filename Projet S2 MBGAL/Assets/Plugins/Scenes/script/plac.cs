using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class plac : MonoBehaviour
{
    // Start is called before the first frame update
    public bool check = true;
    private Jeu test;
    void Start()
    {
       test = new Jeu(1000,1000);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && check)
        {
            print(test.Argent);
            check = false;
        }
    }
}
