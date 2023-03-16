using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarChance : MonoBehaviour
{
    public GameObject Starr;
    
    void Start()
    {
        if (Random.Range(0, 3) == 2)
        {
            Instantiate(Starr, transform.position, transform.rotation);
            PlayerPrefs.SetFloat("MaxStarCount", PlayerPrefs.GetFloat("MaxStarCount", 0) + 1);
            PlayerPrefs.SetFloat("StarCount", PlayerPrefs.GetFloat("StarCount", 0) + 1);
        }
    }
}
