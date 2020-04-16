using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class caserne : MonoBehaviour
{
    public class Caserne : TypeBatiment.Batiment
    {
        private int vie;
        public int prixSoldat;
        public const long prix = 100;

        public int Vie
        {
            get => vie;
            set => vie = value;
        }

        public Caserne()
        {
            type = BatimentType.CASERNE;
        }
        
        public Caserne(Caserne caserne)
        {
            type = caserne.type;
        }

        public bool CreeSoldat(ref long nourriture)
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
