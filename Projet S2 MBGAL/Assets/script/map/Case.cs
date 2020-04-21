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
                batiment = new Tour.tour();
            else if (tuile.batiment.Type == TypeBatiment.BatimentType.CHAMP)
                batiment = new Champ.champ();
            else if (tuile.batiment.Type == TypeBatiment.BatimentType.MAISON)
                batiment = new Maison.maison();
            else if (tuile.batiment.Type == TypeBatiment.BatimentType.CASERNE)
                batiment = new Caserne.caserne();
            else if (tuile.batiment.Type == TypeBatiment.BatimentType.CHATEAU)
                batiment = new Chateau.chateau();
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
                if (type == TypeBatiment.BatimentType.TOUR && bois >= Tour.tour.prix)
                {
                    batiment = new Tour.tour();
                    bois -= Tour.tour.prix;
                }

                if (type == TypeBatiment.BatimentType.CHAMP && bois >= Champ.champ.prix)
                {
                    batiment = new Champ.champ();
                    bois -= Champ.champ.prix;
                }

                if (type == TypeBatiment.BatimentType.MAISON && bois >= Maison.maison.prix)
                {
                    batiment = new Maison.maison();
                    bois -= Maison.maison.prix;
                    logementTot += Maison.maison.logement;
                }

                if (type == TypeBatiment.BatimentType.CASERNE && bois >= Caserne.caserne.prix)
                {
                    batiment = new Caserne.caserne();
                    bois -= Caserne.caserne.prix;
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
                Champ.champ c = new Champ.champ();
                return c.recolte();
            }
            else
            {
                return 0;
            } 
        }

}
