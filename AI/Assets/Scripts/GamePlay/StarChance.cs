using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarChance : MonoBehaviour
{
    public GameObject Starr;
    public bool HasStar;
    public GameObject CurrentStar;
    
    void Start()
    {
        if (Random.Range(0, 3) == 2)
        {
            Instantiate(Starr, transform.position, transform.rotation);
            HasStar = true;
        }
    }

    private void Update()
    {
        
    }

    public void CreateStar()
    {
        CurrentStar = Instantiate(Starr, transform.position, transform.rotation);
    }
}
