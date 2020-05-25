using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ArcherE : MonoBehaviour
{
    private int vie = 50;
    private int dégat = 5;
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
    private bool click = false;
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
            if (cible.gameObject.tag == "Guerrier Allié")
            {
                Guerrier unité2 =  cible.gameObject.GetComponent<Guerrier>();
                unité2.Vie -= dégat;
                if (unité2.Vie <= 0)
                {
                    Destroy(cible.gameObject);
                }

            }
        
            if (cible.gameObject.tag == "Archer")
            {
                Archer unité2 = cible.gameObject.GetComponent<Archer>();
                unité2.Vie -= dégat;
                if (unité2.Vie <= 0)
                {
                    Destroy(cible.gameObject);
                }
            
            }
            if (cible.gameObject.tag == "Ouvrier Allié")
            {
                Ouvrier unité2 = cible.gameObject.GetComponent<Ouvrier>();
                unité2.Vie -= dégat;
                if (unité2.Vie <= 0)
                {
                    Destroy(cible.gameObject);
                }
            }
            if (cible.gameObject.tag == "Tour")
            {
                Tour unité2 = cible.gameObject.GetComponent<Tour>();
                unité2.vie -= dégat;
                if (unité2.vie <= 0)
                {
                    Destroy(cible.gameObject);
                }
            
            }
            if (cible.gameObject.tag == "Caserne")
            {
                Caserne unité2 = cible.gameObject.GetComponent<Caserne>();
                unité2.vie -= dégat;
                if (unité2.vie <= 0)
                {
                    Destroy(cible.gameObject);
                }
            }
            if (cible.gameObject.tag == "Chateau")
            {
                ChateauGestion unité2 = cible.gameObject.GetComponent<ChateauGestion>();
                unité2.Vie -= dégat;
                if (unité2.Vie <=0)
                {
                    Destroy(cible.gameObject);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            if (cible.gameObject.tag == "Champ")
            {
                Champ unité2 = cible.gameObject.GetComponent<Champ>();
                unité2.vie -= dégat;
                if (unité2.vie <= 0)
                {
                    Destroy(cible.gameObject);
                }
            }
            if (cible.gameObject.tag == "Maison")
            {
                Maison unité2 = cible.gameObject.GetComponent<Maison>();
                unité2.vie -= dégat;
                if (unité2.vie <= 0)
                {
                    Destroy(cible.gameObject);
                }
            }
        }
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
            Destroy(gameObject);
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

                if (ally && selection)
                {
                    if (Input.GetMouseButtonUp(1))
                    {

                        NewPosition = new Vector3(hit.point.x, (float) 0.5, hit.point.z);
                        click = true;
                    }
                }
            }

        }

        if (possibleAttack && Input.GetMouseButtonUp(1))
        {
            AttackRange(hit.collider.gameObject);
            LABALLE2 = Instantiate(LABALLE2, transform.position, Quaternion.identity);
            LABALLE2.SetActive(true);

        }


        LABALLE2.transform.position =
            Vector3.MoveTowards(LABALLE2.transform.position, NewPosition, 50 * Time.deltaTime);


    }

    private void OnMouseDown()
    {
        selection = true;
    }
}
