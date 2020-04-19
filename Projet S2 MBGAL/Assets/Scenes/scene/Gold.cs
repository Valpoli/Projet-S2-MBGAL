using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public string nbGold;
    // Start is called before the first frame update
    void Start()
    {
        nbGold = ": 1000";
    }

    public void actualnbGold(int Gold)
    {
        nbGold = ": " + Gold.ToString();
    }
}
