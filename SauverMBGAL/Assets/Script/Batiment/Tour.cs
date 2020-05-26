using UnityEngine;

public class Tour : MonoBehaviour
{
    public class tour : TypeBatiment
    {
        private int vie = 60;
        private int tpsRecharge = 3;
        public const int degatTour = 30;
        public const long prix = 100;
        
        public int Vie
        {
            get => vie;
            set => vie = value;
        }

        public int TpsRecharge
        {
            get => tpsRecharge;
            set => tpsRecharge = value;
        }

        public tour()
        {
            
            type = BatimentType.TOUR;
        }

        public tour(tour tour)
        {
            type = tour.type;
        }

        
    }

    public GameObject target;
    public int range;
    private int dégat = 5;
    public GameObject LABALLE2;
    private Vector3 cible = Vector3.zero;
    public bool Ally;
    public int vie = 200;
    




    public void AttackRange()
    {
        if (target != null)
        {
            Vector3 posCible = target.transform.position;
            Vector3 posArcher = gameObject.transform.position;
            if (range > Vector3.Distance(posCible, posArcher))
            {
                if (target.tag == "Archer Allié")
                {
                    Archer guerrier = target.GetComponent<Archer>();
                    guerrier.Vie -= dégat;
                    LABALLE2 = Instantiate(LABALLE2, posArcher, Quaternion.identity);
                    cible = posCible;
                    if (guerrier.Vie < 0)
                    {
                        Destroy(target);
                    }
                }

                if (target.tag == "Guerrier Allié")
                {
                    Guerrier guerrier = target.GetComponent<Guerrier>();
                    guerrier.Vie -= dégat;
                    LABALLE2 = Instantiate(LABALLE2, posArcher, Quaternion.identity);
                    cible = posCible;
                    if (guerrier.Vie < 0)
                    {
                        Destroy(target);
                    }
                }

                if (target.tag == "Ouvrier Allié")
                {
                    Ouvrier guerrier = target.GetComponent<Ouvrier>();
                    guerrier.Vie -= dégat;
                    LABALLE2 = Instantiate(LABALLE2, posArcher, Quaternion.identity);
                    cible = posCible;
                    if (guerrier.Vie < 0)
                    {
                        Destroy(target);
                    }
                }

                if (target.tag == "Guerrier Ennemie")
                {
                    GuerrierE unité2 = target.GetComponent<GuerrierE>();
                    unité2.Vie -= dégat;
                    LABALLE2 = Instantiate(LABALLE2, posArcher, Quaternion.identity);
                    cible = posCible;
                    if (unité2.Vie < 0)
                    {
                        Destroy(target);
                    }

                }

                if (target.tag == "Archer Ennemie")
                {
                    ArcherE unité2 = target.GetComponent<ArcherE>();
                    unité2.Vie -= dégat;
                    LABALLE2 = Instantiate(LABALLE2, posArcher, Quaternion.identity);
                    cible = posCible;
                    if (unité2.Vie < 0)
                    {
                        Destroy(target);
                    }

                }

                if (target.tag == "Ouvrier Ennemie")
                {
                    OuvrierE unité2 = target.GetComponent<OuvrierE>();
                    unité2.Vie -= dégat;
                    LABALLE2 = Instantiate(LABALLE2, posArcher, Quaternion.identity);
                    cible = posCible;
                    if (unité2.Vie < 0)
                    {
                        Destroy(target);
                    }

                }
            }

        }
    }

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f , 0.5f );
        InvokeRepeating("AttackRange", 0f, 1f);
        
    }

    void UpdateTarget()
    {
        GameObject[] enemiesarcher;
        GameObject[] enemiesGuerrier;
        GameObject[] enemiesouvrier;
        if (Ally)
        {
            enemiesarcher = GameObject.FindGameObjectsWithTag("Archer Ennemie");
            enemiesGuerrier = GameObject.FindGameObjectsWithTag("Guerrier Ennemie");
            enemiesouvrier = GameObject.FindGameObjectsWithTag("Ouvrier Ennemie");
        }
        else
        {
            enemiesarcher = GameObject.FindGameObjectsWithTag("Archer");
            enemiesGuerrier = GameObject.FindGameObjectsWithTag("Guerrier Allié");
            enemiesouvrier = GameObject.FindGameObjectsWithTag("Ouvrier Allié");
        }
        float minDist = Mathf.Infinity;
        GameObject enemy = null;
        foreach (GameObject Target in enemiesarcher)
        {
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
            }
            
        }
        foreach (GameObject Target in enemiesGuerrier)
        {
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
            }
            
        }
        foreach (GameObject Target in enemiesouvrier)
        {
            float distance = Vector3.Distance(transform.position, Target.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                enemy = Target;
            }
            
        }

        if (enemy != null && minDist <= range)
        {
            target = enemy;
        }
        else
        {
            target = null;
        }
        
        
    }

    private void Update()
    {
        LABALLE2.transform.position = Vector3.MoveTowards(LABALLE2.transform.position, cible, 50* Time.deltaTime);
    }
}
