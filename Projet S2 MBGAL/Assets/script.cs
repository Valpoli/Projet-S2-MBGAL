using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class script : MonoBehaviour
{
    public GameObject testt;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Game plop = testt.GetComponent<Game>();
        print(plop.Nourriture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
