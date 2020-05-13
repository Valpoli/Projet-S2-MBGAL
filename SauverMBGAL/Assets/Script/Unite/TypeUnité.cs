using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeUnité : MonoBehaviour
{
    public enum UnitéType
    {
        NONE,
        VILLAGEOIS,
        GUERRIER,
        ARCHER
    }

    protected UnitéType type;

    public UnitéType Type
    {
        get { return type; }
    }
    
    
}