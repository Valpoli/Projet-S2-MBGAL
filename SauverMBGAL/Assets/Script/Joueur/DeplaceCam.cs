using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplaceCam : MonoBehaviour
{
    public Camera cam;
    public float PlateauSpeed;

    private float Bordure = 15f;
    private float MinHauteur = 15f;
    private float MaxHauteur = 100f;


    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        float DeplacementX = Camera.main.transform.position.x;
        float DeplacementZ = Camera.main.transform.position.z;
        float DeplacementY = Camera.main.transform.position.y;

        float PositionX = Input.mousePosition.x;
        float PositionY = Input.mousePosition.y;

        if (DeplacementX > -10 && DeplacementX < 110 && DeplacementZ > -10 && DeplacementZ < 110)
        {
            if (PositionX > -Bordure && PositionX < Bordure)
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

            if (PositionY > -Bordure && PositionY < Bordure)
            {
                DeplacementZ -= PlateauSpeed;
            }

            DeplacementY = Input.GetAxis("Mouse ScrollWheel") * (PlateauSpeed * 50);

            DeplacementY = Mathf.Clamp(DeplacementY, MinHauteur, MaxHauteur);
            if (DeplacementX > -10 && DeplacementX < 110 && DeplacementZ > -10 && DeplacementZ < 110)
            {
                Camera.main.transform.position = new Vector3(DeplacementX, DeplacementY, DeplacementZ);
            }
        }
    }
}

