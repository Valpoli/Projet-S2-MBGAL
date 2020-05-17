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
    private bool selectionDéplacement = false;
    private int range = 4;
    private Vector3 NewPosition = Vector3.zero;
    public int speed;




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

    public bool SelectionDéplacement
    {
        get => selectionDéplacement;
        set => selectionDéplacement = value;
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
                    NewPosition = new Vector3(destination.point.x, (float) 0.5, destination.point.z);

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

