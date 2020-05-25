using UnityEngine;
public class Chateau : MonoBehaviour
{
    public class chateau : TypeBatiment
    {
        public chateau()
        {
            type = BatimentType.CHATEAU;
        }

        public chateau(chateau chateau)
        {
            type = chateau.type;
        }
    }
}
