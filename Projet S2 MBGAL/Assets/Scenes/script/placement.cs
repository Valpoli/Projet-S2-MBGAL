using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class placement : MonoBehaviour
{
    // Start is called before the first frame update
    public int money = 1000;
    public bool check = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && check)
        {
            money -= 100;
            check = false;
        }
    }
}
