using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Tuile : MonoBehaviour
    { 
        public enum Biome
        {
            BOIS,
            MER,
            MONTAGNE,
            PLAINE
        }

        private Batiment batiment;
        private Biome biome;

        public Biome GetBiome
        {
            get { return biome; }
        }

        public Tuile(Biome b)
        {
            biome = b;
            batiment = null;
        }

        public Tuile(Tuile tuile)
        {
            biome = tuile.biome;
            if (tuile.batiment == null)
                batiment = null;
            else if (tuile.batiment.Type == Batiment.BatimentType.TOUR)
                batiment = new Tour();
            else if (tuile.batiment.Type == Batiment.BatimentType.CHAMP)
                batiment = new Champ();
            else if (tuile.batiment.Type == Batiment.BatimentType.MAISON)
                batiment = new Maison();
            else if (tuile.batiment.Type == Batiment.BatimentType.CASERNE)
                batiment = new Caserne();
            else if (tuile.batiment.Type == Batiment.BatimentType.CHATEAU)
                batiment = new Chateau();
        }

        public bool constructible()
        {
            return biome == Biome.PLAINE && batiment == null;
        }

        public bool Construire(ref long bois, ref long logementTot, Batiment.BatimentType type)
        {
            if (!constructible())
            {
                return false;
            }
            else
            {
                if (type == Batiment.BatimentType.TOUR && bois >= Tour.prix)
                {
                    batiment = new Tour();
                    bois -= Tour.prix;
                }

                if (type == Batiment.BatimentType.CHAMP && bois >= Champ.prix)
                {
                    batiment = new Champ();
                    bois -= Champ.prix;
                }

                if (type == Batiment.BatimentType.MAISON && bois >= Maison.prix)
                {
                    batiment = new Maison();
                    bois -= Maison.prix;
                    logementTot += Maison.logement;
                }

                if (type == Batiment.BatimentType.CASERNE && bois >= Caserne.prix)
                {
                    batiment = new Caserne();
                    bois -= Caserne.prix;
                }

                return true;
            }
        }

        public bool Detruire()
        {
            if (batiment != null)
            {
                batiment = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        public long prendreRecolte()
        {
            if (batiment != null && batiment.Type == Batiment.BatimentType.CHAMP)
            {
                Champ c = new Champ();
                return c.recolte();
            }
            else
            {
                return 0;
            }
        }
    }
