using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tour : MonoBehaviour
{
    public class tour : TypeBatiment
    {
        private int vie = 30;
        private int tpsRecharge = 3;
        public const int degatTour = 30;
        public const long prix = 100;

        public int Vie
        {
            get => vie;
            set => vie = value;
        }

        public int TpsRecharge
        {
            get => tpsRecharge;
            set => tpsRecharge = value;
        }

        public tour()
        {
            type = BatimentType.TOUR;
        }

        public tour(tour tour)
        {
            type = tour.type;
        }

        public long degatInflige()
        {
            if (tpsRecharge <= 0)
            {
                return degatTour;
            }
            else
            {
                return 0;
            }
        }
    }
}

