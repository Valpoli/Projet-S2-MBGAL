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

    /// pour position de départ
    private bool dejaBouge;
    private Vector3 posDepart;

    public bool Selection
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

            if (cible.tag == "Chateau")
            {
                ChateauGestion chateau = cible.GetComponent<ChateauGestion>();
                chateau.Vie -= dégat;
                Debug.Log(chateau.Vie);
            }
        }
    }

    public int reactPositionnement(float x,float z, List <(int,int)> list)
    {
        int res = 0;
        bool pasTrouve = true;
        while (res < 9 && pasTrouve)
        {
            if ((float) list[res].Item1 == x && (float) list[res].Item2 == z)
            {
                pasTrouve = false;
            }
            else
            {
                res += 1;
            }
        }

        return res;
    }
    
    

    private void Start()
    {
        dejaBouge = false;
        posDepart = gameObject.transform.position;
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Vie <= 0)
        {
            if (!dejaBouge)
            {
                GameObject cloneHUD = GameObject.FindGameObjectWithTag("HUD");
                Boutons cloneBoutons = cloneHUD.GetComponent<Boutons>();
                int pos = reactPositionnement(posDepart.x, posDepart.z, cloneBoutons.pointSpawn);
                cloneBoutons.emplacementLibre[pos] = false;
            }
            Destroy(gameObject);
        }
        
        
        if (NewPosition != Vector3.zero && click)
        {
            if (!dejaBouge)
            {
                GameObject cloneHUD = GameObject.FindGameObjectWithTag("HUD");
                Boutons cloneBoutons = cloneHUD.GetComponent<Boutons>();
                int pos = reactPositionnement(posDepart.x, posDepart.z, cloneBoutons.pointSpawn);
                cloneBoutons.emplacementLibre[pos] = false;
                dejaBouge = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, NewPosition, speed * Time.deltaTime);
        }

        if (Physics.Raycast(ray, out hit, 100)) 
        {
            if (selection)
            {
                if(hit.collider.gameObject.tag == "Chateau")
                {
                    possibleAttack = true;
                }
                else
                {
                    possibleAttack = false;
                }
            }
            
            if (hit.collider.gameObject.tag == "Map")
            {
                if (Input.GetMouseButtonUp(0))
                {
                    selection = false;
                }
                if (ally && selection)
                {
                    if (Input.GetMouseButtonUp(1))
                    {
                        
                        NewPosition = new Vector3(hit.point.x,(float)0.5,hit.point.z);
                        click = true;
                    }
                }
            }
            
        }

        if (possibleAttack && Input.GetMouseButtonUp(1))
        {
            AttackRange(hit.collider.gameObject);
            deplacement_attack = true;
            tiré = true;
            LABALLE2 = Instantiate(LABALLE2, transform.position, Quaternion.identity);
            LABALLE2.SetActive(true);

        }

        
        LABALLE2.transform.position = Vector3.MoveTowards(LABALLE2.transform.position, NewPosition, 50* Time.deltaTime);
        

    }

    private void OnMouseDown()
    {
        selection = true;
    }
}
