using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSnacks : MonoBehaviour
{
    public float StartDelay;
    public float Intervals;
    public GameObject[] Snackies;

    public GameObject ChipRed;
    public GameObject ChipGreen;
    public GameObject ChipOrange;
    public GameObject ColaRegular;
    public GameObject ColaDiet;
    public GameObject Chocolate;

    private bool valid;

    private void Start()
    {
        valid = true;
    }

    public void RealStart()
    {
        if (valid == true)
        {
            InvokeRepeating(nameof(SpawnSnack), StartDelay, Intervals);
            valid = false;
        }
    }

    void SpawnSnack()
    {
        GameObject ChosenSnack = Snackies[Random.Range(0, 24)];
        if (ChosenSnack.GetComponent<SnackiesMarker>().SnackType == "Chocolate")
        {
            Instantiate(Chocolate, ChosenSnack.transform.position, Quaternion.identity);
        }
        else if(ChosenSnack.GetComponent<SnackiesMarker>().SnackType == "ColaDiet")
        {
            Instantiate(ColaDiet, ChosenSnack.transform.position, Quaternion.identity);
        }
        else if (ChosenSnack.GetComponent<SnackiesMarker>().SnackType == "ColaRegular")
        {
            Instantiate(ColaRegular, ChosenSnack.transform.position, Quaternion.identity);
        }
        else if (ChosenSnack.GetComponent<SnackiesMarker>().SnackType == "ChipRed")
        {
            Instantiate(ChipRed, ChosenSnack.transform.position, Quaternion.identity);
        }
        else if (ChosenSnack.GetComponent<SnackiesMarker>().SnackType == "ChipGreen")
        {
            Instantiate(ChipGreen, ChosenSnack.transform.position, Quaternion.identity);
        }
        else if (ChosenSnack.GetComponent<SnackiesMarker>().SnackType == "ChipOrange")
        {
            Instantiate(ChipOrange, ChosenSnack.transform.position, Quaternion.identity);
        }
    }
}
