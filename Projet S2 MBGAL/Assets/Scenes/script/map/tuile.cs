using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class tuile : MonoBehaviour
    {
        public class Tuile
        {
            public enum Biome
            {
                BOIS, MER, MONTAGNE, PLAINE
            }

            private TypeBatiment.Batiment batiment;
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
                else if (tuile.batiment.Type == TypeBatiment.Batiment.BatimentType.TOUR)
                    batiment = new tour.Tour();
                else if (tuile.batiment.Type == TypeBatiment.Batiment.BatimentType.CHAMP)
                    batiment = new champ.Champ();
                else if (tuile.batiment.Type == TypeBatiment.Batiment.BatimentType.MAISON)
                    batiment = new maison.Maison();
                else if (tuile.batiment.Type == TypeBatiment.Batiment.BatimentType.CASERNE)
                    batiment = new caserne.Caserne();
                else if (tuile.batiment.Type == TypeBatiment.Batiment.BatimentType.CHATEAU)
                    batiment = new chateau.Chateau();
            }

            public bool constructible()
            {
                return biome == Biome.PLAINE && batiment == null;
            }

            public bool Construire(ref long bois, TypeBatiment.Batiment.BatimentType type)
            {
                if (!constructible())
                {
                    return false;
                }
                else
                {
                    if (type == TypeBatiment.Batiment.BatimentType.TOUR && bois >= tour.Tour.prix)
                    {
                        batiment = new tour.Tour();
                        bois -= tour.Tour.prix;
                    }

                    if (type == TypeBatiment.Batiment.BatimentType.CHAMP && bois >= champ.Champ.prix)
                    {
                        batiment = new champ.Champ();
                        bois -= champ.Champ.prix;
                    }

                    if (type == TypeBatiment.Batiment.BatimentType.MAISON && bois >= maison.Maison.prix)
                    {
                        batiment = new maison.Maison();
                        bois -= maison.Maison.prix;
                    }

                    if (type == TypeBatiment.Batiment.BatimentType.CASERNE && bois >= caserne.Caserne.prix)
                    {
                        batiment = new caserne.Caserne();
                        bois -= caserne.Caserne.prix;
                    }

                    if (type == TypeBatiment.Batiment.BatimentType.CHATEAU && bois >= chateau.Chateau.prix)
                    {
                        batiment = new chateau.Chateau();
                        bois -= chateau.Chateau.prix;
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
                if (batiment != null && batiment.Type == TypeBatiment.Batiment.BatimentType.CHAMP)
                {
                     champ.Champ c = new champ.Champ();
                     return c.recolte();
                }
                else
                {
                    return 0;
                }
            }
            
            public long CalcPopulation()
            {
                if (batiment != null && batiment.Type == TypeBatiment.Batiment.BatimentType.MAISON)
                {
                    maison.Maison m = new maison.Maison();
                    return m.Logement();
                }
                if (batiment != null && batiment.Type == TypeBatiment.Batiment.BatimentType.CHATEAU)
                {
                    chateau.Chateau c = new chateau.Chateau();
                    return c.Logement();
                }
                else
                {
                    return 0;
                }
            }

        }
}
