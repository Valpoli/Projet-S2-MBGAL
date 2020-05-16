using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recolte : MonoBehaviour
{
    public GameObject textBois;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        print("Bonjours, etes vous la pour un coatching ?");
        Debug.Log(this.gameObject.name);
    }
}
