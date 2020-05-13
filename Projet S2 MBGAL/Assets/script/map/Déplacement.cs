using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Déplacement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 NewPosition = Vector3.zero;
    public int speed;
    private bool selection = false;

    public void deplacement()
    {

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit destination;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out destination))
            {
                NewPosition = destination.point;
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
    

    private void OnMouseDown()
    {
        selection = true;
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
