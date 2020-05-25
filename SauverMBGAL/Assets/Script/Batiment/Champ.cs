using UnityEngine;
public class Champ : MonoBehaviour
{
    public class champ : TypeBatiment
    {
        private int vie = 25;
        public const long prix = 10;
        public bool Ally;
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
    
    public int vie = 20;
}