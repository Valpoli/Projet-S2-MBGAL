using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject chateau;

    private Chateau.chateau chateau2;

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
        chateau2 = chateau.GetComponent<Chateau.chateau>();
        MaxValue(chateau2.Vie);
    }

    private void Update()
    {
        chateau2 = chateau.GetComponent<Chateau.chateau>();
        SetHealth(chateau2.Vie);
    }
}
