using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carte : MonoBehaviour
{
    public Tuile[,] matrix;

    public Carte()
    {
        Tuile[,] matrix = { { new Tuile(Tuile.Biome.PLAINE), new Tuile(Tuile.Biome.PLAINE) }, { new Tuile(Tuile.Biome.PLAINE), new Tuile(Tuile.Biome.PLAINE) }};
    }
    
    public bool Construire(int i, int j, ref long money,ref long logementTot,
            Batiment.BatimentType type)
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

