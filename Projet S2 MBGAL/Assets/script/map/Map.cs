using System;

public class Map
{
    public Case[,] matrix;

    public Map()
    {
        matrix = Generate();
    }

    public Case[,] Generate()
    {
        Case[,] res = { { new Case(Case.Biome.PLAINE), new Case(Case.Biome.PLAINE) }, { new Case(Case.Biome.PLAINE), new Case(Case.Biome.PLAINE) }};
        return res;
    }


    public bool Construire(int i, int j, ref long money,ref long logementTot,
        TypeBatiment.BatimentType type)
    {
        if (i < 0 || i >= matrix.GetLength(0) || j < 0
            || j >= matrix.GetLength(1))
            return false;
        return matrix[i, j].Construire(ref money,ref logementTot, type);
    }

    public bool Destroy(int i, int j)
    {
        if (i < 0 || i >= matrix.GetLength(0) || j < 0
            || j >= matrix.GetLength(1))
            return false;
        return matrix[i, j].Detruire();
    }


    public int Lines
    {
        get { return matrix.GetLength(0); }
    }

    public int Columns
    {
        get { return matrix.GetLength(1); }
    }
}
