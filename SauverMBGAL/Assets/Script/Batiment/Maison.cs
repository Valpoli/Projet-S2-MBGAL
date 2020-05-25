using UnityEngine;

public class Maison : MonoBehaviour
{
    public class maison : TypeBatiment
    {
        private int vie = 50;
        public const int logement = 10;
        public const long prix = 100;

        public int Vie
        {
            get => vie;
            set => vie = value;
        }

        public maison()
        {
            type = BatimentType.MAISON;
        }
        public maison(maison house)
        {
            type = house.type;
        }
    }

    public int vie = 50;
}