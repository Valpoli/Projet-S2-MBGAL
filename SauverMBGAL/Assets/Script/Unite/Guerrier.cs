using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guerrier : MonoBehaviour
{
    

        private int vie = 50;
        private int dégat = 100;
        public const int logement = 1;
        public const long prixOr = 100;
        public const long prixNouriture = 100;
        private bool isKO = false;
        private bool ally;
        private bool selectionDéplacement = false;
        private int range = 50;


    

        public int Vie
        {
            get => vie;
            set => vie = value;
        }

        public int Dégat
        {
            get => dégat;
            set => dégat = value;
        }

        public bool IsKO
        {
            get => isKO;
            set => isKO = value;
        }

        public bool SelectionDéplacement
        {
            get => selectionDéplacement;
            set => selectionDéplacement = value;
        }

        private void Update()
        {
            if (Vie < 0)
            {
                Destroy(this.gameObject);
            }
        }
    
    
}