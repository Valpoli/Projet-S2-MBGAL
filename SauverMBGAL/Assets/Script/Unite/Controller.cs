using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Vector3 StartPosition;
    private List<TypeUnité> UnitéSéléctioné;


    public static Vector3 GetMouseWorldPosition() {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ() {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

    private void Awake()
    {
        UnitéSéléctioné = new List<TypeUnité>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartPosition = GetMouseWorldPosition();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("#####");
            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(StartPosition, GetMouseWorldPosition());
            foreach (Collider2D collider2D in collider2DArray)
            {
                TypeUnité unité = collider2D.GetComponent<TypeUnité>();
                if (unité != null)
                {
                    UnitéSéléctioné.Add(unité);
                }
                Debug.Log(UnitéSéléctioné.Count);
            }
            
        }
        
    }
}
