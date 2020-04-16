using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class champ : MonoBehaviour
{
    public class Champ : TypeBatiment.Batiment
    {
        private int vie;
        public long prodNourriture;
        public const long prix = 100;
        
        public int Vie
        {
            get => vie;
            set => vie = value;
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
            return prodNourriture;
        }
    }
}
