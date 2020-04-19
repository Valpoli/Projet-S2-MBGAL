using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CU: MonoBehaviour
{
    public class Chateau : Batiment
    {
        private int vie = 300;
        public const int logement = 50;
        public const int prixVillageois = 10;

        public int Vie
        {
            get => vie;
            set => vie = value;
        }

        public Chateau()
        {
            type = BatimentType.CHATEAU;
        }

        public Chateau(Chateau chateau)
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