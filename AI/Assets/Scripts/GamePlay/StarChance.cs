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
            CurrentStar = Instantiate(Starr, transform.position, transform.rotation);
            HasStar = true;
            Time.timeScale = 1;
        }
    }

    private void Update()
    {
        if (HasStar == true)
        {
            if (CurrentStar == null)
            {
                HasStar = false;
                Invoke("CreateStar", 25);
            }
        }
    }

    public void CreateStar()
    {
        CurrentStar = Instantiate(Starr, transform.position, transform.rotation);
        HasStar = true;
    }
}
