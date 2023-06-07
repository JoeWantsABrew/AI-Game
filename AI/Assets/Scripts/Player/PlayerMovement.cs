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
    public AudioSource JumpFx;

    public GameObject HUD;
    public Joystick Joystuck;

    public AudioSource Music;


    private void Awake()
    {
        PlayerPrefs.SetFloat("StarPower", 0);
        Time.timeScale = 1;
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
            Music.pitch = 0.4f;
            Time.timeScale = 0;
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
                Music.pitch = 0.4f;
                Time.timeScale = 0;
            }
        }
    }

    public void Jump()
    {
        if (true)
        {
            PlayerRB.velocity = (new Vector2(PlayerRB.velocity.x, JumpPower));
            float Pitchy = UnityEngine.Random.Range(0.8f, 1.2f);
            JumpFx.pitch = Pitchy;
            JumpFx.Play();
        }
    }
}
