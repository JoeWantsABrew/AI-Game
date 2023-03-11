using System.Collections;
using System.Collections.Generic;
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
        PlayerRB.velocity += (new Vector2(speed * Input.GetAxis("Horizontal"), 0));

        if (Input.GetAxis("Vertical") != 0)
        {
            if (HasJump == true)
            {
                PlayerRB.velocity = (new Vector2(PlayerRB.velocity.x, Input.GetAxis("Vertical") * JumpPower));
                HasJump = false;
            }
        }
        StarCount = PlayerPrefs.GetFloat("StarCount", 0);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == floorTag)
        {
            HasJump = true;
        }

        if (collision.collider.tag == StarTag)
        {
            Instantiate(DeadlyStar, collision.collider.transform.position, collision.collider.transform.rotation);
            Destroy(collision.gameObject);
        }

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
}
