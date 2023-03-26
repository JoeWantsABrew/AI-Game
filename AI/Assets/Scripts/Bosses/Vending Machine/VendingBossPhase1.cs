using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingBossPhase1 : MonoBehaviour
{
    public Rigidbody2D rb;

    public float MaxWalkSpeed;
    public float WalkSpeed;
    public float DashPower;

    public GameObject Target;

    private void Start()
    {
        Target = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Attack", 5, 3);
    }

    void FixedUpdate()
    {
        Walk();
    }

    public void Walk()
    {
        if (Target.transform.position.x < transform.position.x)
        {
            if (rb.velocity.magnitude < MaxWalkSpeed)
            {
                rb.velocity = new Vector2(-WalkSpeed + rb.velocity.x, rb.velocity.y);
            }
        }
        else
        {
            if (rb.velocity.magnitude < MaxWalkSpeed)
            {
                rb.velocity = new Vector2(WalkSpeed + rb.velocity.x, rb.velocity.y);
            }
        }
    }

    public void Attack()
    {
        if ((transform.position - Target.transform.position).magnitude > 20f)
        {
            RangedAttack();
        }
        else
        {
            rb.velocity = (Target.transform.position - transform.position).normalized * DashPower;
        }
    }

    public void RangedAttack()
    {
        if (Random.Range(1, 3) > 2)
        {

        }
    }
}
