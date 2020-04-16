using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeBatiment : MonoBehaviour
{
    public abstract class Batiment
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
}

