using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampRecolte : MonoBehaviour
{
    public Texture champVide;
    public Texture champPlein;
    public GameObject ouvrierType;
    private bool recoltable = false;
    private int tpsDePousse = 5;
    private int rendement = 200;
    private bool enCours = false;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.mainTexture = champVide;
        StartCoroutine(ChampPousse());
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(ouvrierType.tag))
        {
            if (recoltable)
            {
                Ouvrier cloneOuvrier = other.gameObject.GetComponent<Ouvrier>();
                cloneOuvrier.stocknourriture += rendement;
                rend.material.mainTexture = champVide;
                recoltable = false;
                StartCoroutine(ChampPousse());
            }
        }
    }
    IEnumerator ChampPousse()
    {
        enCours = true;
        yield return new WaitForSeconds(tpsDePousse);
        recoltable = true;
        enCours = false;
        rend.material.mainTexture = champPlein;
    }
}
