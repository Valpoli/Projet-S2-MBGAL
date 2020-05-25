using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuvrierE : MonoBehaviour
{
    private int vie = 40;
    private int dégat = 3;
    public const int logement = 1;
    public const long prixOr = 100;
    public const long prixNouriture = 100;
    private bool isKO = false;
    public bool ally;
    private Vector3 NewPosition = Vector3.zero;
    public int speed = 1;
    public int stockor = 0;
    public int stocknourriture = 0;
    private int dégatrecolte = 5;

    /// pour le bot
    public bool enAction = false;
    
    public Vector3 posChateau = new Vector3(88, (float) 0.5, 88);
    private Vector3 dest = new Vector3(0, 0, 0);

    public int Vie
    {
        get => vie;
        set => vie = value;
    }

    public int Dégat
    {
        get => dégat;
        set => dégat = value;
    }

    public bool IsKO
    {
        get => isKO;
        set => isKO = value;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "arbre(Clone)")
        {
            Arbre cible = other.gameObject.GetComponent<Arbre>();
            cible.pv -= dégatrecolte;
            stockor += dégatrecolte;
            dest = posChateau;
        }

        if (other.gameObject.name == "ChateauE(Clone)")
        {
            ouvrierEnAction();
        }
    }

    private void Start()
    {
        ouvrierEnAction();
    }

    private void Update()
    {
        if (Vie < 0)
        {
            Destroy(gameObject);
        }
        Game clonePartie = GameObject.FindGameObjectWithTag("Player").GetComponent<Game>();
        if (clonePartie.map.matrix[Construction.posDansMatrice(dest).Item1, Construction.posDansMatrice(dest).Item2]
                .GetBiome == Case.Biome.PLAINE && dest != posChateau)
        {
            ouvrierEnAction();
        }
        transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);

    }

    public void ouvrierEnAction()
    {
        GameObject[] listArbres;
        listArbres = GameObject.FindGameObjectsWithTag("Arbre");
        float minDist = Mathf.Infinity;
        GameObject arbreVise = null;
        foreach (GameObject Target in listArbres)
        {
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                arbreVise = Target;
            }
        }
        dest = arbreVise.transform.position;
    }
}
