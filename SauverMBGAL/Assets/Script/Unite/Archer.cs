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
    private bool selectionDéplacement = false;
    public int speed;
    private Vector3 NewPosition = Vector3.zero;
    public bool ally;
    private bool possibleAttack = false;
    public GameObject LABALLE2;
    


    public bool SelectionDéplacement
    {
        get => selectionDéplacement;
        set => selectionDéplacement = value;
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

            selectionDéplacement = false;


        }
        
    }
    public void LABALLE(GameObject LABALLE, Vector3 posDépart, Vector3 posFinal)
    {
        LABALLE.transform.position = Vector3.MoveTowards(posDépart, posFinal, Time.deltaTime);
        Debug.Log("ENVOYER");
    }
    
    public void deplacement()
    {
        if (ally)
        {
            if (Input.GetMouseButtonUp(0))
            {
                RaycastHit destination;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out destination))
                {
                    NewPosition = new Vector3(destination.point.x,(float)0.5,destination.point.z);
                    
                }
            }
            
            
            
            if (NewPosition != Vector3.zero)
            {
                
                transform.position = Vector3.MoveTowards(transform.position, NewPosition, speed * Time.deltaTime);
            }
        }
    }

    

    private void Update()
    {
        if (Vie < 0)
        {
            Destroy(gameObject);
        }
        if (Input.GetMouseButtonUp(1))
        {
            selectionDéplacement = false;
        }

        if (selectionDéplacement)
        {
            deplacement();
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100)) 
        {
            if(hit.collider.tag == "Ennemie")
            {
                possibleAttack = true;

            }
            else
            {
                possibleAttack = false;
            }
        }

        if (possibleAttack && Input.GetMouseButtonUp(0))
        {
            AttackRange(hit.collider.gameObject);
            LABALLE2.transform.position = gameObject.transform.position;
            LABALLE(LABALLE2,LABALLE2.transform.position,hit.collider.gameObject.transform.position);
        }
    }
    private void OnMouseDown()
    {
        selectionDéplacement = true;
    }
}
