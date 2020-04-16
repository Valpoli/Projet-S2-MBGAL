using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class maison : MonoBehaviour
{
    public class Maison : TypeBatiment.Batiment
    {
        private int vie;
        public int logement;
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
