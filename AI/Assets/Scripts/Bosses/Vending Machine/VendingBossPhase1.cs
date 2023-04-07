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
    public HealthManager health;
    public GameObject Transition;

    public Animator anim;
    private string State = "MachineDance";

    private void Start()
    {
        Target = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(RangedAttack), 7, 5);
        InvokeRepeating(nameof(AttackAnim), 6.5f, 5);
        anim = GetComponent<Animator>();
        health = GetComponent<HealthManager>();
    }

    void FixedUpdate()
    {
        if (health.currentPhase == 0)
        {
            Walk();
            anim.Play(State);
        }
    }

    public void Walk()
    {
        rb.velocity = (Target.transform.position - transform.position).normalized * WalkSpeed;
        if (Target.transform.position.x >= transform.position.x)
        {
            transform.localScale = new Vector2(-1.5f, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(1.5f, transform.localScale.y);
        }
    }



    public void RangedAttack()
    {
        if (health.currentPhase == 0)
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
        else
        {
            CancelInvoke();
        }
    }

    public void AttackAnim()
    {
        if (health.currentPhase == 0)
        {
            State = "MachineAttack1";
            Invoke(nameof(StopWalking), 1.1f);
        }
    }
    
    public void StopWalking()
    {
        State = "MachineDance";
        Debug.Log("Animation???");
    }

    public void Phase2Start()
    {
        GetComponent<VendingMachinePhase2>().Begin();
        Transition.SetActive(true);
        Invoke(nameof(DeactivateTrans), 1.2f);
    }

    public void DeactivateTrans()
    {
        Destroy(Transition.gameObject);
    }
}
