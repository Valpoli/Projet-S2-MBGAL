using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonMaison : MonoBehaviour
{
    public GameObject clone;
    public void ConstrMaison()
    {
        Game cloneGame = clone.GetComponent<Game>();
        cloneGame.needMaison = true;
    }
    
    
}
