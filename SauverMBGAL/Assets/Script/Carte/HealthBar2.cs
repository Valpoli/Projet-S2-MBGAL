using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar2 : MonoBehaviour
{
    public Slider slider;
    private int Maxhealth = 500;
    

    public void MaxValue(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
 
        

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    private void Start()
    {
        MaxValue(Maxhealth);
    }

    private void Update()
    {
        GameObject chateau = GameObject.FindGameObjectWithTag("Chateau Ennemie");
        if (chateau != null)
        {
            ChateauGestion chateau2 = chateau.GetComponent<ChateauGestion>();
            SetHealth(chateau2.Vie);
        }

    }
}

