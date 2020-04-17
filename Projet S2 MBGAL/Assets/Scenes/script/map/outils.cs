using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outils : MonoBehaviour
{
    
    public static void instancier(UnityEngine.Vector3 posCurseur, Transform prefab)
    {
        float axex = posCurseur.x;
        float axez = posCurseur.y;
        if (axex - Convert.ToInt16(axex) != 0)
        {
            axex += 1;
        }
        if (axez - Convert.ToInt16(axez) != 0)
        {
            axez += 1;
        }

        int x = Convert.ToInt16(axex);
        int z = Convert.ToInt16(axez);
        Instantiate(prefab, new Vector3(1, 1, 1), Quaternion.identity);
        
    }
    
}
