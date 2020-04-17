using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carte : MonoBehaviour
{
    public Tuile[,] matrix;
    
    public Carte()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                matrix[i, j] = new Tuile(Tuile.Biome.PLAINE);
            }
        }
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

