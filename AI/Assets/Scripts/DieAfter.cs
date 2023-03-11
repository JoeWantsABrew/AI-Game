using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfter : MonoBehaviour
{
    public float Ttime;
    private void Start()
    {
        Destroy(this.gameObject, Ttime);
    }
}
