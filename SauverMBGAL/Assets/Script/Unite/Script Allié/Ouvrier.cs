using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ouvrier : MonoBehaviour
{
    // Start is called before the first frame update
    private int vie = 40;
    private int dégat = 3;
    public const int logement = 1;
    public const long prixOr = 100;
    public const long prixNouriture = 100;
    private bool isKO = false;
    public bool ally;
    private bool selection = false;
    private Vector3 NewPosition = Vector3.zero;
    public int speed;
    private bool click = false;
    public int stockor = 0;
    public int stocknourriture = 0;
    private int dégatrecolte = 5;
    /// pour position de départ
    private bool dejaBouge;
    private Vector3 posDepart;



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
        }
        if (other.gameObject.CompareTag("Chateau Allié"))
        {
            Game clonePartie = GameObject.FindGameObjectWithTag("Player").GetComponent<Game>();
            clonePartie.nourriture += stocknourriture;
            stocknourriture = 0;
            clonePartie.argent += stockor;
            stockor = 0;
        }
        
    }
    
    public int reactPositionnement(float x, float z, List<(int, int)> list)
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
        if (Vie < 0)
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

        if (ally && selection)
        {
            if (Input.GetMouseButtonUp(1))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    NewPosition = new Vector3(hit.point.x, (float) 0.5, hit.point.z);
                    click = true;
                }
            }
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
            

            if (hit.collider.gameObject.tag == "Map")
            {
                if (Input.GetMouseButtonUp(0))
                {
                    selection = false;
                    
                }
            }
            
        }
    }

    private void OnMouseDown()
    {
        selection = true;
    }

    
}
