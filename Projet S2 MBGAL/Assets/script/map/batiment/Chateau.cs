using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Chateau : MonoBehaviour
{
    public class chateau : TypeBatiment
    {
        private int vie = 500;
        public const int logement = 50;
        public const int prixVillageois = 10;

        public int Vie
        {
            get => vie;
            set => vie = value;
        }

        public chateau()
        {
            type = BatimentType.CHATEAU;
        }

        public chateau(chateau chateau)
        {
            type = chateau.type;
        }

        public bool CreeVillageois(ref long nourriture)
        {
            bool res = true;
            if (nourriture >= prixVillageois)
            {
                nourriture -= prixVillageois;
            }
            else
            {
                res = false;
            }

            return res;
        }

        public long Logement()
        {
            return logement;
        }
    }
}

