using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingBossPhase1 : MonoBehaviour
{
    public Rigidbody2D rb;

    public float WalkSpeed;

    public GameObject Target;
    public GameObject Soda;
    public GameObject Chips;

    private void Start()
    {
        Target = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("RangedAttack", 7, 5);
    }

    void FixedUpdate()
    {
        Walk();
    }

    public void Walk()
    {
        rb.velocity = (Target.transform.position - transform.position).normalized * WalkSpeed;
    }



    public void RangedAttack()
    {
        if (Random.Range(1, 3) > 1)
        {
            Instantiate(Chips, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(Soda, transform.position, transform.rotation);
        }
    }
}
