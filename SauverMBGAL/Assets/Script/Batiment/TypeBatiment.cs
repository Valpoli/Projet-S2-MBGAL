public abstract class TypeBatiment
{
    public enum BatimentType
    {
        NONE,
        MAISON,
        TOUR,
        CHATEAU,
        CASERNE,
        CHAMP
    }

    protected BatimentType type;

    public BatimentType Type
    {
        get { return type; }
    }
}
