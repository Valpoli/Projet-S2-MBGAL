using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Transform prefab;
    public Camera cam;
    public bool check = true;

    public float PlateauSpeed;

    private float Bordure = 15f;
    private float MinHauteur = 10f;
    private float MaxHauteur = 100f;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && check)
        { 
            print(cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f)));
            ///outils.instancier(Input.mousePosition,prefab);
            check = false;
        }
        if (Input.GetMouseButtonDown(1))
        { 
            check = true;
        }
    }
    void MoveCamera()
    {
        float DeplacementX = Camera.main.transform.position.x;
        float DeplacementZ = Camera.main.transform.position.z;
        float DeplacementY = Camera.main.transform.position.y;

        float PositionX = Input.mousePosition.x;
        float PositionY = Input.mousePosition.y;

        if (PositionX > 0 && PositionX < Bordure)
        {
            DeplacementX -= PlateauSpeed;

        }
        if (PositionX < Screen.width && PositionX > Screen.width - Bordure)
        {
            DeplacementX += PlateauSpeed;
        }
        if (PositionY < Screen.height && PositionY > Screen.height - Bordure)
        {
            DeplacementZ += PlateauSpeed;
        }
        if (PositionY > 0 && PositionY < Bordure)
        {
            DeplacementZ -= PlateauSpeed;
        }

        DeplacementY = Input.GetAxis("Mouse ScrollWheel")* (PlateauSpeed * 50);

        DeplacementY = Mathf.Clamp(DeplacementY, MinHauteur, MaxHauteur);

        Camera.main.transform.position = new Vector3(DeplacementX, DeplacementY, DeplacementZ);
    }
}
