﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GuerrierE : MonoBehaviour
{
    private int vie = 100;
    private int dégat = 1;
    public const int logement = 1;
    public const long prixOr = 100;
    public const long prixNouriture = 100;
    private bool isKO = false;
    public bool ally;
    private Vector3 NewPosition = Vector3.zero;
    public int speed;
    private GameObject target;
    public int range = 60;
    private bool posA = true;
    private bool enAttaque;
    
    
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

    


    private void OnCollisionStay(Collision other)
    {
        
        
        if (other.gameObject.tag == "Guerrier Allié")
        {
            Guerrier unité2 = other.gameObject.GetComponent<Guerrier>();
            unité2.Vie -= dégat;
            if (unité2.Vie <= 0)
            {
                Game cloneJoueur = GameObject.FindGameObjectWithTag("Player").GetComponent<Game>();
                {
                    cloneJoueur.popAct -= 1;
                }
                Guerrier cloneGuerrier = target.GetComponent<Guerrier>();
                if (!cloneGuerrier.dejaBouge)
                {
                    GameObject cloneHUD = GameObject.FindGameObjectWithTag("HUD");
                    Boutons cloneBoutons = cloneHUD.GetComponent<Boutons>();
                    int pos = cloneGuerrier.reactPositionnement(cloneGuerrier.posDepart.x, cloneGuerrier.posDepart.z, cloneBoutons.pointSpawn);
                    cloneBoutons.emplacementLibre[pos] = false;
                }
                Destroy(other.gameObject);
            }

        }
        
        if (other.gameObject.tag == "Archer")
        {
            Archer unité2 = other.gameObject.GetComponent<Archer>();
            unité2.Vie -= dégat;
            if (unité2.Vie <= 0)
            {
                Game cloneJoueur = GameObject.FindGameObjectWithTag("Player").GetComponent<Game>();
                {
                    cloneJoueur.popAct -= 1;
                }
                Archer cloneArcher = target.GetComponent<Archer>();
                if (!cloneArcher.dejaBouge)
                {
                    GameObject cloneHUD = GameObject.FindGameObjectWithTag("HUD");
                    Boutons cloneBoutons = cloneHUD.GetComponent<Boutons>();
                    int pos = cloneArcher.reactPositionnement(cloneArcher.posDepart.x, cloneArcher.posDepart.z, cloneBoutons.pointSpawn);
                    cloneBoutons.emplacementLibre[pos] = false;
                }
                Destroy(other.gameObject);
            }
            
        }
        if (other.gameObject.tag == "Ouvrier Allié")
        {
            Ouvrier unité2 = other.gameObject.GetComponent<Ouvrier>();
            unité2.Vie -= dégat;
            if (unité2.Vie <= 0)
            {
                Game cloneJoueur = GameObject.FindGameObjectWithTag("Player").GetComponent<Game>();
                {
                    cloneJoueur.popAct -= 1;
                }
                Ouvrier cloneOuvrier = target.GetComponent<Ouvrier>();
                if (!cloneOuvrier.dejaBouge)
                {
                    GameObject cloneHUD = GameObject.FindGameObjectWithTag("HUD");
                    Boutons cloneBoutons = cloneHUD.GetComponent<Boutons>();
                    int pos = cloneOuvrier.reactPositionnement(cloneOuvrier.posDepart.x, cloneOuvrier.posDepart.z, cloneBoutons.pointSpawn);
                    cloneBoutons.emplacementLibre[pos] = false;
                }
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == "Tour")
        {
            Tour unité2 = other.gameObject.GetComponent<Tour>();
            unité2.vie -= dégat;
            if (unité2.vie <= 0)
            {
                Destroy(other.gameObject);
            }
            
        }
        if (other.gameObject.tag == "Caserne")
        {
            Caserne unité2 = other.gameObject.GetComponent<Caserne>();
            unité2.vie -= dégat;
            if (unité2.vie <= 0)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == "Chateau Allié")
        {
            ChateauGestion unité2 = other.gameObject.GetComponent<ChateauGestion>();
            unité2.Vie -= dégat;
            if (unité2.Vie <= 0)
            {
                Destroy(other.gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if (other.gameObject.tag == "Champ")
        {
            Champ unité2 = other.gameObject.GetComponent<Champ>();
            unité2.vie -= dégat;
            if (unité2.vie <= 0)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == "Maison")
        {
            Maison unité2 = other.gameObject.GetComponent<Maison>();
            unité2.vie -= dégat;
            if (unité2.vie <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
    void UpdateTarget()
    {
        GameObject[] enemiesarcher = GameObject.FindGameObjectsWithTag("Archer");
        GameObject[] enemiesGuerrier = GameObject.FindGameObjectsWithTag("Guerrier Allié");
        GameObject[] enemiesouvrier = GameObject.FindGameObjectsWithTag("Ouvrier Allié");
        GameObject[] enemiesMaison = GameObject.FindGameObjectsWithTag("Maison");
        GameObject[] enemiesChamp = GameObject.FindGameObjectsWithTag("Champ");
        GameObject[] enemiesChateau= GameObject.FindGameObjectsWithTag("Chateau Allié");
        GameObject[] enemiesCaserne = GameObject.FindGameObjectsWithTag("Caserne");
        GameObject[] enemiesTour = GameObject.FindGameObjectsWithTag("Tour");
        
        
              
        float minDist = Mathf.Infinity;
        GameObject enemy = null;
        Vector3 pos = Vector3.zero;
        foreach (GameObject Target in enemiesarcher)
        { 
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                pos = Target.transform.position;
                NewPosition = Target.transform.position;
                enemy = Target;
            }
              
        }
        foreach (GameObject Target in enemiesTour)
        { 
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
                NewPosition = Target.transform.position;
                pos = Target.transform.position;
            }
              
        }
        foreach (GameObject Target in enemiesMaison)
        { 
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
                NewPosition = Target.transform.position;
                pos = Target.transform.position;
            }
              
        }
        foreach (GameObject Target in enemiesouvrier)
        { 
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
                NewPosition = Target.transform.position;
                pos = Target.transform.position;
            }
              
        }
        foreach (GameObject Target in enemiesChamp)
        { 
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
                NewPosition = Target.transform.position;
                pos = Target.transform.position;
            }
              
        }
        foreach (GameObject Target in enemiesCaserne)
        { 
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
                NewPosition = Target.transform.position;
                pos = Target.transform.position;
            }
              
        }

        foreach (GameObject Target in enemiesGuerrier)
        {
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
                pos = Target.transform.position;
                NewPosition = Target.transform.position;
            }
        }

        foreach (GameObject Target in enemiesChateau)
        {
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
                NewPosition = Target.transform.position;
            }
              
        }
              
        if (enemy != null)
        {

            target = enemy;
        }
        else
        {
            target = null;
        }
        
              
    }



    private void Update()
    {
        Bot cloneBot = GameObject.FindGameObjectWithTag("Bot").GetComponent<Bot>();
        if (cloneBot.Charger)
        {
            enAttaque = true;
        }
        if (enAttaque)
        {
            if (transform.position == new Vector3(50, 1, 50))
            {
                posA = false;
            }

            if (range > Vector3.Distance(transform.position, NewPosition))
            {
                transform.position = Vector3.MoveTowards(transform.position, NewPosition, speed * Time.deltaTime);
            }

            if (posA)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, new Vector3(50, 1, 50), 5 * Time.deltaTime);
            }
        }



    }

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }
}
