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

    public string DieTag;
    public GameObject DeathScreen;
    public GameObject DeathFX;
    public string BossTag;

    public GameObject HUD;
    public Joystick Joystuck;


    private void Awake()
    {
        PlayerPrefs.SetFloat("StarPower", 0);
    }

    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        Joystuck = GameObject.FindObjectOfType<Joystick>();
        HUD = GameObject.Find("HUD");
    }

    private void FixedUpdate()
    {
        PlayerRB.velocity += (new Vector2(speed * Joystuck.Horizontal, 0));
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
        if (collision.collider.tag == BossTag)
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
