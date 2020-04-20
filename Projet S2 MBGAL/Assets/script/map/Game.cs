using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public long score;
    public long logementTot;
    public long argent;
    public long nourriture;
    public Map map = new Map();
    public bool needAnInput = false;
    
    void Start()
    {
        Camera cam = Camera.main;
        if (needAnInput && Input.GetMouseButtonDown(0))
        {
            Vector3 clic = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.x,10f));
            calcCentre(clic);
        }
    }

    // Update is called once per frame
    void Update()
    {
        print(nourriture);
    }

    public void InputSomething()
    {
        needAnInput = true;
    }
    public int[] calcCentre(Vector3 clic)
    {
        float x = clic.x;
        float z = clic.z;
        int posx = Convert.ToInt16(x);
        int posz = Convert.ToInt16(z);
        int[] res = {-1,-1};
        if (posx >= 0 || posx <= 100 || posz >= 0 || posz <= 100)
        {
            if (x - posx != 0)
            {
                posx = +1;
            }
            if (z - posz != 0)
            {
                posz = +1;
            }
            while (posx % 4 == 0)
            {
                posx += 1;
            }
            while (posz % 4 == 0)
            {
                posz += 1;
            }
            posx -= 2;
            posz -= 2;
            res[0] = posx;
            res[1] = posz;
        }
        return res;
    }
}


