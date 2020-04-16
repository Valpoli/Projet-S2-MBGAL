using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform spwanerPos;
    public GameObject spawnee;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(spawnee, spwanerPos.position, spwanerPos.rotation);
        }
    }
}
