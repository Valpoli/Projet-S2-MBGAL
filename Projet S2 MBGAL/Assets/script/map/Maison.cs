using System;

public class Maison : TypeBatiment
{
    private int vie = 50;
    public const int logement = 10;
    public const long prix = 100;

    public int Vie
    {
        get => vie;
        set => vie = value;
    }

    public Maison()
    {
        type = BatimentType.MAISON;
    }

    public Maison(Maison house)
    {
        type = house.type;
    }

    public long Logement()
    {
        return logement;
    }
}

