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
    public SpriteRenderer Sproot;
    public Animator animm;
    public VendingBossPhase1 Boss1;
    
    private Vector2 Desire;
    private Vector2 PlayerLoc;
    private bool Begun;
    private string state = "MahcnineFaceNormal";

    private void Start()
    {
        Target = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        Begun = false;
        Sproot = gameObject.GetComponent<SpriteRenderer>();
        animm = gameObject.GetComponent<Animator>();
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
        Sproot.enabled = false;
        Boss1.enabled = false;  
    }

    private void FixedUpdate()
    {
        if (Begun == true)
        {
            Walk();
            animm.Play(state);

        }
    }

    public void GetHit()
    {
        Debug.Log("Hit animation?");
        state = "MachineFaceDamaged";
        Invoke(nameof(NormalAnimation), 0.1f);
    }

    public void NormalAnimation()
    {
        state = "MahcnineFaceNormal";
        Debug.Log("Hit animation done?");
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
