using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Tour : MonoBehaviour
{
    public class tour : TypeBatiment
    {
        private int vie = 30;
        private int tpsRecharge = 3;
        public const int degatTour = 30;
        public const long prix = 100;
        private bool target = false;
        

        public int Vie
        {
            get => vie;
            set => vie = value;
        }

        public int TpsRecharge
        {
            get => tpsRecharge;
            set => tpsRecharge = value;
        }

        public tour()
        {
            type = BatimentType.TOUR;
        }

        public tour(tour tour)
        {
            type = tour.type;
        }

        
    }

    public GameObject target;
    public int range;
    private int dégat = 5;
    private bool attente = false;
    public GameObject LABALLE2;
    private Vector3 cible = Vector3.zero;
    
    
    public void AttackRange()
    {
        if (target != null)
        {
            Vector3 posCible = target.transform.position;
            Vector3 posArcher = gameObject.transform.position;
            if (range > Vector3.Distance(posCible, posArcher))
            {
                if (target.tag == "Archer")
                {
                    Archer guerrier = target.GetComponent<Archer>();
                    guerrier.Vie -= dégat;
                    LABALLE2 = Instantiate(LABALLE2, posArcher, Quaternion.identity);
                    cible = posCible;

                }
            }
        }
        
    }
    
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f , 0.5f );
        InvokeRepeating("AttackRange", 0f, 1f);
        
    }

    void UpdateTarget()
    {
        GameObject[] enemiesarcher = GameObject.FindGameObjectsWithTag("Archer");
        GameObject[] enemiesGuerrier = GameObject.FindGameObjectsWithTag("Guerrier Allié");
        GameObject[] enemiesouvrier = GameObject.FindGameObjectsWithTag("Villageois Allié");
        
        float minDist = Mathf.Infinity;
        GameObject enemy = null;
        foreach (GameObject Target in enemiesarcher)
        {
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
            }
            
        }
        foreach (GameObject Target in enemiesGuerrier)
        {
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
            }
            
        }
        foreach (GameObject Target in enemiesouvrier)
        {
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
            }
            
        }

        if (enemy != null && minDist <= range)
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
        LABALLE2.transform.position = Vector3.MoveTowards(LABALLE2.transform.position, cible, 50* Time.deltaTime);
    }
}
