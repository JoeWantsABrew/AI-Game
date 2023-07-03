using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachinePhase2 : MonoBehaviour
{
    public GameObject Target;
    public Transform PlayerTeleport;
    public Transform GoHere;
    public GameObject Face;
    public float Speed;
    public Rigidbody2D rb;
    public float MoveInterval;
    public DropSnacks Snacker;
    
    private Vector2 Desire;
    private Vector2 PlayerLoc;
    private bool Begun;


    private void Start()
    {
        Target = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        Begun = false;
    }

    public void Begin()
    {
        Invoke(nameof(BeginReal), 0.5f);
        ProjectileHere[] Projectiles = GameObject.FindObjectsOfType<ProjectileHere>();
        foreach (ProjectileHere thingy in Projectiles)
        {
            Destroy(thingy.gameObject);
        }
    }

    public void BeginReal()
    {
        Target.transform.position = PlayerTeleport.transform.position;
        transform.position = GoHere.position;
        Face.SetActive(true);
        PlayerLoc = Target.transform.position;
        Begun = true;
        Snacker.RealStart();
    }

    private void FixedUpdate()
    {
        if (Begun == true)
        {
            Walk();
        }
    }

    public void Walk()
    {
        Vector2 MyPos = transform.position;
        rb.velocity = (PlayerLoc - MyPos).normalized * Speed;
        if ((PlayerLoc - MyPos).magnitude < 5)
        {
            Invoke(nameof(AlternateWalk), MoveInterval);
        }
    }

    public void AlternateWalk()
    {
        PlayerLoc = Target.transform.position;
    }
}
