using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joueur : MonoBehaviour
{
    public Game aya = new Game(5,5 );
    
    
    // Start is called before the first frame update
    void Start()
    {
        long test = aya.Nourriture + 50;
        print(aya.Nourriture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
