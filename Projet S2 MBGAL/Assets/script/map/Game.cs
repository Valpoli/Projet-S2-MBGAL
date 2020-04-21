using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Game : MonoBehaviour
{
    public long score;
    public long logementTot;
    public long argent;
    public long nourriture;
    public Map map = new Map();
    public bool needAnInput;
    private Camera cam;
    private int cameraCurrentZoom = 8;
    public GameObject Maison;
    void Start()
    {
        cam = Camera.main;
        Camera.main.orthographicSize = cameraCurrentZoom;
        needAnInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (needAnInput && Input.GetMouseButtonDown(0))
        {
            Vector3 clic = cam.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(clic); 
            calcCentre(clic);
            construireMaison(calcCentre(clic));
            needAnInput = false;
        }
        
    }
    
    public Vector3 calcCentre(Vector3 clic)
    {
        bool check = false;
        string test = "PAS DANS LA MAP";
        if (clic.x >= 0 && clic.x <= 100 && clic.z >= 0 && clic.z <= 100)
        {
            double x = Math.Round(clic.x);
            double z = Math.Round(clic.z);
            while (x % 4 != 0 || x == 0)
            {
                x += 1;
            }
            while (z % 4 != 0 || z == 0)
            {
                z += 1;
            }
            x -= 2;
            z -= 2;
            test = Convert.ToString(x) + " , " +  Convert.ToString(z);
            check = true;
            clic.x = (float)x;
            clic.z = (float)z;

        }
        Debug.Log(test);
        Debug.Log(check);
        return clic;
    }

    public void construireMaison(Vector3 clic)
    {
        clic.y = (float)0.5;
        Instantiate(Maison, clic, Quaternion.identity);
    }


}


