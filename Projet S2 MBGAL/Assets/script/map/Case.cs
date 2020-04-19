public class Case
    { 
        public enum Biome
        {
            BOIS,
            MER,
            MONTAGNE,
            PLAINE
        }

        private TypeBatiment batiment;
        private Biome biome;

        public Biome GetBiome
        {
            get { return biome; }
        }

        public Case(Biome b)
        {
            biome = b;
            batiment = null;
        }

        public Case(Case tuile)
        {
            biome = tuile.biome;
            if (tuile.batiment == null)
                batiment = null;
            else if (tuile.batiment.Type == TypeBatiment.BatimentType.TOUR)
                batiment = new Tour();
            else if (tuile.batiment.Type == TypeBatiment.BatimentType.CHAMP)
                batiment = new Champ();
            else if (tuile.batiment.Type == TypeBatiment.BatimentType.MAISON)
                batiment = new Maison();
            else if (tuile.batiment.Type == TypeBatiment.BatimentType.CASERNE)
                batiment = new Caserne();
            else if (tuile.batiment.Type == TypeBatiment.BatimentType.CHATEAU)
                batiment = new Chateau();
        }

        public bool constructible()
        {
            return biome == Biome.PLAINE && batiment == null;
        }

        public bool Construire(ref long bois, ref long logementTot, TypeBatiment.BatimentType type)
        {
            if (!constructible())
            {
                return false;
            }
            else
            {
                if (type == TypeBatiment.BatimentType.TOUR && bois >= Tour.prix)
                {
                    batiment = new Tour();
                    bois -= Tour.prix;
                }

                if (type == TypeBatiment.BatimentType.CHAMP && bois >= Champ.prix)
                {
                    batiment = new Champ();
                    bois -= Champ.prix;
                }

                if (type == TypeBatiment.BatimentType.MAISON && bois >= Maison.prix)
                {
                    batiment = new Maison();
                    bois -= Maison.prix;
                    logementTot += Maison.logement;
                }

                if (type == TypeBatiment.BatimentType.CASERNE && bois >= Caserne.prix)
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

        public long PrendreRecolte()
        {
            if (batiment != null && batiment.Type == TypeBatiment.BatimentType.CHAMP)
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
