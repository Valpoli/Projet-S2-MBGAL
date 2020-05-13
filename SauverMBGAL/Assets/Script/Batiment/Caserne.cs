using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Caserne : MonoBehaviour
{
    public class caserne : TypeBatiment
    {
        private int vie = 20;
        public const int prixSoldat = 30;
        public const long prix = 300;

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

        public static bool CreeSoldat(ref long nourriture)
        {
            bool res = true;
            if (nourriture >= prixSoldat)
            {
                nourriture -= prixSoldat;
            }
            else
            {
                res = false;
            }

            return res;
        }
    }
}