using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guerrier : MonoBehaviour
{


    private int vie = 50;
    private int dégat = 20;
    public const int logement = 1;
    public const long prixOr = 100;
    public const long prixNouriture = 100;
    private bool isKO = false;
    public bool ally;
    private bool selection = false;
    private int range = 4;
    private Vector3 NewPosition = Vector3.zero;
    public int speed;
    private bool click = false;




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

        if (other.gameObject.name == "Soldat ennemie")
        {
            Guerrier unité2 = other.gameObject.GetComponent<Guerrier>();
            unité2.Vie -= dégat;
            if (unité2.Vie < 0)
            {
                Destroy(gameObject);
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
            transform.position = Vector3.MoveTowards(transform.position, NewPosition, speed * Time.deltaTime);
        }
        
        if (Physics.Raycast(ray, out hit, 100)) 
        {

            if (hit.collider.gameObject.name == "guerrier")
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
    

    
}


