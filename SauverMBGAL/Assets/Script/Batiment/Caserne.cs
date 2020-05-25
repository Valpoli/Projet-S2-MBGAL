using UnityEngine;
public class Caserne : MonoBehaviour
{
    public class caserne : TypeBatiment
    {
        private int vie = 20;
        public const long prix = 300;
        public int Vie
        {
            get => vie;
            set => vie = value;
        }
        public caserne()
        {
            type = BatimentType.CASERNE;
        }

        public caserne(caserne caserne)
        {
            type = caserne.type;
        }
    }
}