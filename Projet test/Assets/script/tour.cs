using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class tour : MonoBehaviour
{
    public class Tour : TypeBatiment.Batiment
    {
        private int vie;
        public int degatTour;
        public const long prix = 100;

        public int Vie
        {
            get => vie;
            set => vie = value;
        }

        public Tour()
        {
            type = BatimentType.TOUR;
        }
        
        public Tour(Tour tour)
        {
            type = tour.type;
        }

        public long degatInflige()
        {
            return degatTour;
        }
    }
}