using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandPitch : MonoBehaviour
{
    public float Min;
    public float Max;
    public AudioSource Audi;

    private void Start()
    {
        Audi.pitch = Random.Range(Min, Max);
    }
}
