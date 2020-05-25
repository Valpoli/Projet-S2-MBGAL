using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balle : MonoBehaviour
{
    public void destruction()
    { 
        StartCoroutine(DESTROY(gameObject));
    }

    IEnumerator DESTROY(GameObject Piou)
    {
        yield return new WaitForSeconds(1);
        Piou.SetActive(false);
    }

    private void Start()
    {
        destruction();
        
    }
}
