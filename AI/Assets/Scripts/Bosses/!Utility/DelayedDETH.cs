using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDETH : MonoBehaviour
{
    public float Interval;
    public GameObject ColliderNasty;


    private void Start()
    {
        Invoke(nameof(DoIT), Interval);
    }

    public void DoIT()
    {
        ColliderNasty.SetActive(true);
    }
}
