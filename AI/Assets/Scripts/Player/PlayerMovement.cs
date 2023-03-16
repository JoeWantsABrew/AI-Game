using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D PlayerRB;
    public float speed;
    public float JumpPower;
    public string floorTag;

    public string StarTag;
    public float StarCount;
    public GameObject DeadlyStar;

    public string DieTag;
    public GameObject DeathScreen;
    public GameObject DeathFX;
    public string SpiderTag;

    public GameObject HUD;
    public Joystick Joystuck;

    private bool HasJump;

    private void Awake()
    {
        PlayerPrefs.SetFloat("StarCount", 0);
        PlayerPrefs.SetFloat("MaxStarCount", 0);
    }

    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerRB.velocity += (new Vector2(speed * Joystuck.Horizontal, 0));


        StarCount = PlayerPrefs.GetFloat("StarCount", 0);
        HasJump = Physics2D.OverlapCircle(transform.position, 1.2f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.tag == DieTag)
        {
            DeathScreen.SetActive(true);
            HUD.SetActive(false);
            Destroy(this.gameObject);
            Instantiate(DeathFX, transform.position, transform.rotation);
        }
        if (collision.collider.tag == SpiderTag)
        {
            SPider spood = collision.collider.GetComponent<SPider>();
            if (spood.CanHurt)
            {
                DeathScreen.SetActive(true);
                HUD.SetActive(false);
                Destroy(this.gameObject);
                Instantiate(DeathFX, transform.position, transform.rotation);
            }
        }
    }

    public void Jump()
    {
        if (true)
        {
            PlayerRB.velocity = (new Vector2(PlayerRB.velocity.x, JumpPower));
        }
    }
}
