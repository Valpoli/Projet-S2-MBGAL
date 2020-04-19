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
                batiment = new T.Tour();
            else if (tuile.batiment.Type == Batiment.BatimentType.CHAMP)
                batiment = new CP.Champ();
            else if (tuile.batiment.Type == Batiment.BatimentType.MAISON)
                batiment = new M.Maison();
            else if (tuile.batiment.Type == Batiment.BatimentType.CASERNE)
                batiment = new CE.Caserne();
            else if (tuile.batiment.Type == Batiment.BatimentType.CHATEAU)
                batiment = new CU.Chateau();
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
                if (type == Batiment.BatimentType.TOUR && bois >= T.Tour.prix)
                {
                    batiment = new T.Tour();
                    bois -= T.Tour.prix;
                }

                if (type == Batiment.BatimentType.CHAMP && bois >= CP.Champ.prix)
                {
                    batiment = new CP.Champ();
                    bois -= CP.Champ.prix;
                }

                if (type == Batiment.BatimentType.MAISON && bois >= M.Maison.prix)
                {
                    batiment = new M.Maison();
                    bois -= M.Maison.prix;
                    logementTot += M.Maison.logement;
                }

                if (type == Batiment.BatimentType.CASERNE && bois >= CE.Caserne.prix)
                {
                    batiment = new CE.Caserne();
                    bois -= CE.Caserne.prix;
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
                CP.Champ c = new CP.Champ();
                return c.recolte();
            }
            else
            {
                return 0;
            }
        }
    }
