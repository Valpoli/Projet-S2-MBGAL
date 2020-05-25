public class Map
{
    public Case[,] matrix = new Case[25,25];

    public Map()
    {
        matrix = Generate();
    }
    public Case[,] Generate()
    {
        int i = 0;
        while (i < 25)
        {
            int j = 0;
            while (j < 25)
            {
                matrix[i, j] = new Case(Case.Biome.PLAINE);
                j += 1;
            }
            i += 1;
        }
        return matrix;
    }
    
    public bool Construire(int i, int j, ref long money,ref long logementTot,
        TypeBatiment.BatimentType type)
    {
        if (i < 0 || i >= matrix.GetLength(0) || j < 0
            || j >= matrix.GetLength(1))
            return false;
        return matrix[i, j].Construire(ref money,ref logementTot, type);
    }
}