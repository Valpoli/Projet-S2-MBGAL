using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joueur : MonoBehaviour
{
    public Game aya = new Game(5,5 );
    
    
    // Start is called before the first frame update
    void Start()
    {
        long a = aya.Nourriture;
        a +=  50;
        print(a);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
