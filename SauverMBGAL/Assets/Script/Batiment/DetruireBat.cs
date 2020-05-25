using UnityEngine;

public class DetruireBat : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameObject clone = GameObject.FindGameObjectWithTag("Player");
        Game clonePartie = clone.GetComponent<Game>();
        if (clonePartie.needDestruction)
        {
            Destroy(this.gameObject);
        }
    }

}
