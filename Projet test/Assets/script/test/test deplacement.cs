using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class deplacement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject surface;
    public bool check = true;
    public  UnityEngine.Vector2 coin2 = Input.mousePosition;
    void Start()
    {
        print(coin2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && check)
        {
            Object.Instantiate(surface, Input.mousePosition,  Quaternion.identity);
            check = false;
            selection(Input.mousePosition, check);
        }
    }

    public void selection(Vector2 coin1, bool check)
    {
        while (Input.GetMouseButtonDown(0))
        {
                UnityEngine.Vector2 coin2 = Input.mousePosition;
                (float,float) centre = ((coin1.x + coin2.x) / 2, (coin1.y + coin2.y)/2);
                surface.transform.position = Input.mousePosition;
        }
        check = true;
        Destroy(surface);
    }
}
