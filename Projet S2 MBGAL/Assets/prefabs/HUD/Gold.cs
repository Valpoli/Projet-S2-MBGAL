using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public Text nbGold;
    // Start is called before the first frame update
    void Start()
    {
        nbGold.text = ": 1000";
    }

    public void actualnbGold(int Gold)
    {
        nbGold.text = ": " + Gold.ToString();
    }
}
