using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M : MonoBehaviour
{ 
    public class Maison : Batiment
    {
        private int vie = 50;
        public const int logement = 10;
        public const long prix = 100;

        public int Vie
        {
            get => vie;
            set => vie = value;
        }

        public Maison()
        {
            type = BatimentType.MAISON;
        }

        public Maison(Maison house)
        {
            type = house.type;
        }

        public long Logement()
        {
            return logement;
        }
    }
}
