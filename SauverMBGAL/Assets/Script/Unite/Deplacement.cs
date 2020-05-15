using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 NewPosition = Vector3.zero;
    public int speed;
    private bool selection = false;
    public int dégat;
    public int range;
    public bool team;

    public void deplacement()
    {
        if (team)
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
                selection = false;
            }
            
            
            if (NewPosition != Vector3.zero)
            {
                transform.position = Vector3.MoveTowards(transform.position, NewPosition, speed * Time.deltaTime);
                
            }
        }
        
        
    }
    
    

    private void OnMouseDown()
    {
        Debug.Log(transform);
        selection = true;
        Vector3 position = gameObject.transform.position; 
        if (gameObject.name == "Soldat ennemie")
        {
            
            Guerrier unité2 = gameObject.GetComponent<Guerrier>();
            unité2.Vie -= dégat;
            if (unité2.Vie < 0)
            {
                Destroy(gameObject);
            }
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (selection)
        {
            deplacement();
        }
    }    
}

