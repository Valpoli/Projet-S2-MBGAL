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
    private int range = 50;
    private bool selectionDéplacement = false;
    public int speed;
    private Vector3 NewPosition = Vector3.zero;
    public bool ally;
    


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
            if (Input.GetMouseButtonUp(1))
            {
                selectionDéplacement = false;
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

        if (selectionDéplacement)
        {
            deplacement();
        }

    }
    private void OnMouseDown()
    {
        selectionDéplacement = true;
    }
}
