using System;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Caserne : MonoBehaviour
{
    public class caserne : TypeBatiment
    {
        private int vie = 50;
        public const long prix = 300;
        public bool Ally;
        public int Vie
        {
            get => vie;
            set => vie = value;
        }
        public caserne()
        {
            type = BatimentType.CASERNE;
        }

        public caserne(caserne caserne)
        {
            type = caserne.type;
        }
    }

    public int vie = 50;
}