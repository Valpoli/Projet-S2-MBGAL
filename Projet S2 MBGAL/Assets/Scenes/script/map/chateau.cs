using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class chateau : MonoBehaviour
{
    public class Chateau : TypeBatiment.Batiment
    {
        private int vie;
        public int logement;
        public int prixVillageois;
        public const long prix = 100;
        
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