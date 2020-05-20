using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampRecolte : MonoBehaviour
{
    private bool recoltable = false;
    private int tpsDePousse = 5;
    // Start is called before the first frame update
    void Start()
    {
        tpsPousse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("je suis collisionné!");
    }

    public void tpsPousse()
    {
        StartCoroutine(champPousse());
    }
    IEnumerator champPousse()
    {
        yield return new WaitForSeconds(tpsDePousse);
        recoltable = true;
    }
}
