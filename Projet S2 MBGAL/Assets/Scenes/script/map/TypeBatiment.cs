using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Batiment : MonoBehaviour
{
    public enum BatimentType
    {
        NONE, MAISON, TOUR, CHATEAU, CASERNE, CHAMP
    }

    protected BatimentType type;

    public BatimentType Type
    {
        get { return type; }
    }
    
}
