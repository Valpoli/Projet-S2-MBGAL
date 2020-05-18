using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Archer : MonoBehaviour
{
    private int vie = 50;
    private int dégat = 20;
    public const int logement = 1;
    public const long prixOr = 100;
    public const long prixNouriture = 100;
    private bool isKO = false;
    public int range;
    private bool selection = false;
    public int speed;
    private Vector3 NewPosition = Vector3.zero;
    public bool ally;
    private bool possibleAttack = false;
    public GameObject LABALLE2;
    private bool deplacement_attack = true;
    private bool click = false;
    private bool tiré = false;
    private bool enCoursDattaque = true;
    private Vector3 posEnnemy = Vector3.zero;

    public bool SelectionDéplacement
    {
        get => selection;
        set => selection = value;
    }

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
    
    
    
    public void AttackRange(GameObject cible)
    {
        Vector3 posCible = cible.transform.position;
        Vector3 posArcher = gameObject.transform.position;
        if (range > Vector3.Distance(posCible, posArcher))
        {
            if (cible.name == "Soldat ennemie")
            {
                Guerrier guerrier = cible.GetComponent<Guerrier>();
                guerrier.Vie -= dégat;
            }
        }
    }



    private void Update()
    {

        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Vie < 0)
        {
            Destroy(gameObject);
        }
        
        if (ally && selection )
        {
            if (Input.GetMouseButtonUp(1))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    NewPosition = new Vector3(hit.point.x,(float)0.5,hit.point.z);
                    click = true;
                }
            }
        }
        if (NewPosition != Vector3.zero && click && deplacement_attack)
        {
            transform.position = Vector3.MoveTowards(transform.position, NewPosition, speed * Time.deltaTime);
        }

        if (Physics.Raycast(ray, out hit, 100)) 
        {
            if (selection)
            {
                if(hit.collider.gameObject.tag == "Ennemie")
                {
                    possibleAttack = true;
                    
                    Vector3 posCible = hit.collider.gameObject.transform.position;
                    Vector3 posArcher = gameObject.transform.position;
                    if (range > Vector3.Distance(posCible, posArcher))
                    {
                        deplacement_attack = false;
                    }

                    posEnnemy = hit.collider.gameObject.transform.position;
                }
                else
                {
                    possibleAttack = false;
                }
            }

            if (hit.collider.gameObject.name == "Archer")
            {
                if (Input.GetMouseButtonUp(0))
                {
                    selection = true;
                }
            }

            if (hit.collider.gameObject.tag == "Map")
            {
                if (Input.GetMouseButtonUp(0))
                {
                    selection = false;
                    
                }
            }
            
        }

        if (possibleAttack && Input.GetMouseButtonUp(1))
        {
            AttackRange(hit.collider.gameObject);
            deplacement_attack = true;
            tiré = true;
            LABALLE2 = Instantiate(LABALLE2, transform.position, Quaternion.identity);

        }

        if (tiré)
        {
            LABALLE2.transform.position = Vector3.MoveTowards(LABALLE2.transform.position, NewPosition, 50* Time.deltaTime);
        }

    }
    
}
