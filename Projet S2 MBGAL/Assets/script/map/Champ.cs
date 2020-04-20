﻿using System;
public class Champ : TypeBatiment
{
    private int vie = 10;
    private long tpsPousse = 20;
    public const long prodNourriture = 5;
    public const long prix = 10;

    public int Vie
    {
        get => vie;
        set => vie = value;
    }

    public long TpsPousse
    {
        get => tpsPousse;
        set => tpsPousse = value;
    }

    public Champ()
    {
        type = BatimentType.CHAMP;
    }

    public Champ(Champ champ)
    {
        type = champ.type;
    }

    public long recolte()
    {

        if (tpsPousse <= 0)
        {
            return prodNourriture;
        }
        else
        {
            return 0;
        }
    }
}
