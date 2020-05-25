using UnityEngine;
public class Champ : MonoBehaviour
{
    public class champ : TypeBatiment
    {
        private int vie = 10;
        public const long prix = 10;
        public int Vie
        {
            get => vie;
            set => vie = value;
        }
        public champ()
        {
            type = BatimentType.CHAMP;
        }
        public champ(champ champ)
        {
            type = champ.type;
        }
    }
}