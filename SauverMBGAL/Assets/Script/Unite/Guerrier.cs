using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guerrier : MonoBehaviour
{
    public class guerrier: TypeUnité
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


        public guerrier()
        {
            type = UnitéType.GUERRIER;
        }

        public guerrier(guerrier guerrier)
        {
            type = guerrier.type;
        }

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






        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.name == "Maison")
            {
                Maison.maison Cible = other.gameObject.GetComponent<Maison.maison>();
                int CibleVie = Cible.Vie;
                CibleVie -= dégat;
                if (CibleVie < 0)
                {
                    Destroy(other.gameObject);
                }
            }

            if (other.gameObject.name == "Chateau")
            {
                Chateau.chateau Cible = other.gameObject.GetComponent<Chateau.chateau>();
                int CibleVie = Cible.Vie;
                CibleVie -= dégat;
                if (CibleVie < 0)
                {
                    Destroy(other.gameObject);
                }
            }

            if (other.gameObject.name == "Caserne")
            {
                Caserne.caserne Cible = other.gameObject.GetComponent<Caserne.caserne>();
                int CibleVie = Cible.Vie;
                CibleVie -= dégat;
                if (CibleVie < 0)
                {
                    Destroy(other.gameObject);
                }
            }

            if (other.gameObject.name == "Champ")
            {
                Champ.champ Cible = other.gameObject.GetComponent<Champ.champ>();
                int CibleVie = Cible.Vie;
                CibleVie -= dégat;
                if (CibleVie < 0)
                {
                    Destroy(other.gameObject);
                }

                ;
            }

            if (other.gameObject.name == "Tour")
            {
                Tour.tour Cible = other.gameObject.GetComponent<Tour.tour>();
                int CibleVie = Cible.Vie;
                CibleVie -= dégat;
                if (CibleVie < 0)
                {
                    Destroy(other.gameObject);
                }
            }

            if (other.gameObject.name == "Guerrier")
            {
                Guerrier.guerrier Cible = other.gameObject.GetComponent<Guerrier.guerrier>();
                int CibleVie = Cible.Vie;
                CibleVie -= dégat;
                if (CibleVie < 0)
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}