using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Guerrier : MonoBehaviour
{


    private int vie = 100;
    private int dégat = 1;
    public const int logement = 1;
    public const long prixOr = 100;
    public const long prixNouriture = 100;
    private bool isKO = false;
    public bool ally;
    private bool selection = false;
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

    


    private void OnCollisionStay(Collision other)
    {
        
        if (other.gameObject.tag == "Guerrier Ennemie")
        {
            GuerrierE unité2 = other.gameObject.GetComponent<GuerrierE>();
            unité2.Vie -= dégat;
            if (unité2.Vie <= 0)
            {
                Destroy(other.gameObject);
            }

        }

        if (other.gameObject.tag == "Archer Ennemie")
        {
            ArcherE unité2 = other.gameObject.GetComponent<ArcherE>();
            unité2.Vie -= dégat;
            if (unité2.Vie <= 0)
            {
                Destroy(other.gameObject);
            }

        }

        if (other.gameObject.tag == "Ouvrier Ennemie")
        {
            OuvrierE unité2 = other.gameObject.GetComponent<OuvrierE>();
            unité2.Vie -= dégat;
            if (unité2.Vie <= 0)
            {
                Destroy(other.gameObject);
            }

        }

        if (other.gameObject.tag == "Tour Ennemie")
        {
            Tour unité2 = other.gameObject.GetComponent<Tour>();
            unité2.vie -= dégat;
            if (unité2.vie <= 0)
            {
                Destroy(other.gameObject);
            }

        }

        if (other.gameObject.tag == "Caserne Ennemie")
        {
            Caserne unité2 = other.gameObject.GetComponent<Caserne>();
            unité2.vie -= dégat;
            if (unité2.vie <= 0)
            {
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.tag == "Chateau Ennemie")
        {
            ChateauGestion unité2 = other.gameObject.GetComponent<ChateauGestion>();
            unité2.Vie -= dégat;
            if (unité2.Vie <=0)
            {
                Destroy(other.gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
        }
        if (other.gameObject.tag == "Champ Ennemie")
        {
            Champ unité2 = other.gameObject.GetComponent<Champ>();
            unité2.vie -= dégat;
            if (unité2.vie <= 0)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == "Maison Ennemie")
        {
            Maison unité2 = other.gameObject.GetComponent<Maison>();
            unité2.vie -= dégat;
            if (unité2.vie <= 0)
            {
                Destroy(other.gameObject);
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


