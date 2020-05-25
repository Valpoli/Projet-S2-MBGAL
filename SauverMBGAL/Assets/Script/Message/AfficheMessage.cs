using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class AfficheMessage : MonoBehaviour
{
    public Text ManqueArgent;
    public Text DejaBatiment;
    public Text PasDansCarte;
    public Text ManqueNourriture;
    public Text PasDeCaserne;
    public Text PopMax;
    public Text RienADetruire;
    public Text BougerTroupe;

    public void MessageErreur(string error)
    {
        if (ManqueArgent.enabled)
        {
            ManqueArgent.enabled = false;
        }
        if (DejaBatiment.enabled)
        {
            DejaBatiment.enabled = false;
        }
        if (PasDansCarte.enabled)
        {
            PasDansCarte.enabled = false;
        }
        if (ManqueNourriture.enabled)
        {
            ManqueNourriture.enabled = false;
        }
        if (PasDeCaserne.enabled)
        {
            PasDeCaserne.enabled = false;
        }
        if (PopMax.enabled)
        {
            PopMax.enabled = false;
        }
        if (RienADetruire.enabled)
        {
            RienADetruire.enabled = false;
        }
        if (BougerTroupe.enabled)
        {
            BougerTroupe.enabled = false;
        }
        if (error == "ManqueArgent")
        {
            StartCoroutine(ManqueArgentTempo());
        }
        if (error == "DejaBatiment")
        {
            StartCoroutine(DejaBatimentTempo());
        }
        if (error == "PasDansCarte")
        {
            StartCoroutine(PasDansCarteTempo());
        }
        if (error == "ManqueNourriture")
        {
            StartCoroutine(ManqueNourritureTempo());
        }
        if (error == "PasDeCaserne")
        {
            StartCoroutine(PasDeCaserneTempo());
        }
        if (error == "PopMax")
        {
            StartCoroutine(PopMaxTempo());
        }
        if (error == "RienADetruire")
        {
            StartCoroutine(RienADetruireTempo());
        }
        if (error == "BougerTroupe")
        {
            StartCoroutine(BougerTroupeTempo());
        }
    }

    IEnumerator ManqueArgentTempo()
    {
        ManqueArgent.enabled = true;
        yield return new WaitForSeconds(3);
        ManqueArgent.enabled = false;
    }
    IEnumerator DejaBatimentTempo()
    {
        DejaBatiment.enabled = true;
        yield return new WaitForSeconds(3);
        DejaBatiment.enabled = false;
    }
    IEnumerator PasDansCarteTempo()
    {
        PasDansCarte.enabled = true;
        yield return new WaitForSeconds(3);
        PasDansCarte.enabled = false;
    }
    IEnumerator ManqueNourritureTempo()
    {
        ManqueNourriture.enabled = true;
        yield return new WaitForSeconds(3);
        ManqueNourriture.enabled = false;
    }
        
    IEnumerator PasDeCaserneTempo()
    {
        PasDeCaserne.enabled = true;
        yield return new WaitForSeconds(3);
        PasDeCaserne.enabled = false;
    }
        
    IEnumerator PopMaxTempo()
    {
        PopMax.enabled = true;
        yield return new WaitForSeconds(3);
        PopMax.enabled = false;
    }
    IEnumerator RienADetruireTempo()
    {
        RienADetruire.enabled = true;
        yield return new WaitForSeconds(3);
        RienADetruire.enabled = false;
    }
    IEnumerator BougerTroupeTempo()
    {
        BougerTroupe.enabled = true;
        yield return new WaitForSeconds(3);
        BougerTroupe.enabled = false;
    }
}