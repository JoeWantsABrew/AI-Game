using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripWire : MonoBehaviour
{
    public GameObject SwitchOn;
    public GameObject SwitchOffOther;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SwitchOn.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        SwitchOn.SetActive(false);
        SwitchOffOther.SetActive(false);
    }
}
