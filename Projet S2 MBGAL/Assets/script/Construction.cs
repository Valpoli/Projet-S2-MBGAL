﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


public class Construction : MonoBehaviour
{
    public GameObject clone;
    public static bool DanslaCarte(Vector3 clic)
    { 
        bool res = clic.x >= 0 && clic.x <= 100 && clic.z >= 0 && clic.z <= 100;
        return res;
    }
    public static bool DansleChateau(Vector3 clic)
    {
        bool res = !(clic.x <= 24 && clic.x >= 20 && clic.z<= 16 && clic.z >= 12);
        if (clic.x <= 64 && clic.x >= 56 && clic.z<= 64 && clic.z >= 56)
        {
            res = false;
        }
        return res;
    }
    
    public static Vector3 calcCentre(Vector3 clic)
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
        clic.x = (float)x;
        clic.z = (float)z;
        return clic;
    }
    
    public static (int, int) posDansMatrice(Vector3 clic)
    {
        int i = Convert.ToInt16(clic.x - 2);
        int j = Convert.ToInt16(clic.z - 2);
        if (i != 0)
        {
            i /= 4;
        }
        if (j != 0)
        { 
            j /= 4;
        }
        (int, int) res = (i, j);
        return res;
    }
}