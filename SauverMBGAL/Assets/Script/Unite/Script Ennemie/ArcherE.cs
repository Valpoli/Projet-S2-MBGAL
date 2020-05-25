using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcherE : MonoBehaviour
{
    private int vie = 75;
    private int dégat = 5;
    public const int logement = 1;
    public const long prixOr = 100;
    public const long prixNouriture = 100;
    private bool isKO = false;
    public int range;
    private int range2 = 40;
    private bool selection = false;
    public int speed;
    private Vector3 NewPosition = Vector3.zero;
    public bool ally;
    private bool possibleAttack = false;
    public GameObject LABALLE2;
    private bool click = false;
    private Vector3 posEnnemy = Vector3.zero;
    public GameObject target;
    private Vector3 cible;

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



    


    public void AttackRange()
    {
        if (target != null)
        {
            Vector3 posCible = target.transform.position;
            Vector3 posArcher = gameObject.transform.position;
            if (range > Vector3.Distance(posCible, posArcher))
            {
                if (target.gameObject.tag == "Guerrier Allié")
                {
                    Guerrier unité2 = target.gameObject.GetComponent<Guerrier>();
                    unité2.Vie -= dégat;
                    cible = posCible;
                    LABALLE2.SetActive(true);
                    LABALLE2 = Instantiate(LABALLE2, posArcher, Quaternion.identity);
                    if (unité2.Vie <= 0)
                    {
                        Destroy(target.gameObject);
                    }
                }



                if (target.gameObject.tag == "Archer")
                {
                    Archer unité2 = target.gameObject.GetComponent<Archer>();
                    unité2.Vie -= dégat;
                    cible = posCible;
                    LABALLE2.SetActive(true);
                    LABALLE2 = Instantiate(LABALLE2, posArcher, Quaternion.identity);
                    if (unité2.Vie <= 0)
                    {
                        Destroy(target.gameObject);
                    }
                }

                if (target.gameObject.tag == "Ouvrier Allié")
                {
                    Ouvrier unité2 = target.gameObject.GetComponent<Ouvrier>();
                    unité2.Vie -= dégat;
                    cible = posCible;
                    LABALLE2.SetActive(true);
                    LABALLE2 = Instantiate(LABALLE2, posArcher, Quaternion.identity);
                    if (unité2.Vie <= 0)
                    {
                        Destroy(target.gameObject);
                    }
                }

                if (target.gameObject.tag == "Tour")
                {
                    Tour unité2 = target.gameObject.GetComponent<Tour>();
                    unité2.vie -= dégat;
                    cible = posCible;
                    LABALLE2.SetActive(true);
                    LABALLE2 = Instantiate(LABALLE2, posArcher, Quaternion.identity);
                    if (unité2.vie <= 0)
                    {
                        Destroy(target.gameObject);
                    }

                }

                if (target.gameObject.tag == "Caserne")
                {
                    Caserne unité2 = target.gameObject.GetComponent<Caserne>();
                    unité2.vie -= dégat;
                    cible = posCible;
                    LABALLE2.SetActive(true);
                    LABALLE2 = Instantiate(LABALLE2, posArcher, Quaternion.identity);
                    if (unité2.vie <= 0)
                    {
                        Destroy(target.gameObject);
                    }
                }

                if (target.gameObject.tag == "Chateau Allié")
                {
                    ChateauGestion unité2 = target.gameObject.GetComponent<ChateauGestion>();
                    unité2.Vie -= dégat;
                    cible = posCible;
                    LABALLE2.SetActive(true);
                    LABALLE2 = Instantiate(LABALLE2, posArcher, Quaternion.identity);
                    if (unité2.Vie <= 0)
                    {
                        Destroy(target.gameObject);
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }

                if (target.gameObject.tag == "Champ")
                {
                    Champ unité2 = target.gameObject.GetComponent<Champ>();
                    unité2.vie -= dégat;
                    cible = posCible;
                    LABALLE2.SetActive(true);
                    LABALLE2 = Instantiate(LABALLE2, posArcher, Quaternion.identity);
                    if (unité2.vie <= 0)
                    {
                        Destroy(target.gameObject);
                    }
                }

                if (target.gameObject.tag == "Maison")
                {
                    Maison unité2 = target.gameObject.GetComponent<Maison>();
                    unité2.vie -= dégat;
                    cible = posCible;
                    LABALLE2.SetActive(true);
                    LABALLE2 = Instantiate(LABALLE2, posArcher, Quaternion.identity);
                    if (unité2.vie <= 0)
                    {
                        Destroy(target.gameObject);
                    }
                }

            }
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemiesarcher = GameObject.FindGameObjectsWithTag("Archer");
        GameObject[] enemiesGuerrier = GameObject.FindGameObjectsWithTag("Guerrier Allié");
        GameObject[] enemiesouvrier = GameObject.FindGameObjectsWithTag("Ouvrier Allié");
        GameObject[] enemiesMaison = GameObject.FindGameObjectsWithTag("Maison");
        GameObject[] enemiesChamp = GameObject.FindGameObjectsWithTag("Champ");
        GameObject[] enemiesChateau= GameObject.FindGameObjectsWithTag("Chateau Allié");
        GameObject[] enemiesCaserne = GameObject.FindGameObjectsWithTag("Caserne");
        GameObject[] enemiesTour = GameObject.FindGameObjectsWithTag("Tour");
        
        
              
        float minDist = Mathf.Infinity;
        GameObject enemy = null;
        Vector3 pos = Vector3.zero;
        foreach (GameObject Target in enemiesarcher)
        { 
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                pos = Target.transform.position;
                enemy = Target;
            }
              
        }
        foreach (GameObject Target in enemiesTour)
        { 
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
                pos = Target.transform.position;
            }
              
        }
        foreach (GameObject Target in enemiesMaison)
        { 
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
                pos = Target.transform.position;
            }
              
        }
        foreach (GameObject Target in enemiesouvrier)
        { 
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
                pos = Target.transform.position;
            }
              
        }
        foreach (GameObject Target in enemiesChamp)
        { 
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
                pos = Target.transform.position;
            }
              
        }
        foreach (GameObject Target in enemiesCaserne)
        { 
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
                pos = Target.transform.position;
            }
              
        }

        foreach (GameObject Target in enemiesGuerrier)
        {
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
                pos = Target.transform.position;
            }
        }

        foreach (GameObject Target in enemiesChateau)
        {
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
                pos = Target.transform.position;
            }
              
        }
              
        if (enemy != null && minDist <= range2)
        {
            target = enemy;
        }
        else
        {
            if (range2 > Vector3.Distance(transform.position, pos) )
            {
                transform.position = Vector3.MoveTowards(transform.position, pos ,   50 * Time.deltaTime);
            }

            target = null;
        }
        
              
    }



        

    
    private void Update()
    {
        LABALLE2.transform.position = Vector3.MoveTowards(LABALLE2.transform.position, cible, 50 * Time.deltaTime);
    }
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        InvokeRepeating("AttackRange", 0f, 1f);

    }
    
}
