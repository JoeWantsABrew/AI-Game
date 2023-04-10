using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLaunch : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform Target;
    public float speed;
    public float maxspeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Target = GameObject.FindObjectOfType<PlayerMovement>().transform;
        Invoke("DestroyNow", 10);
    }

    private void FixedUpdate()
    {
        //applying velocity towards the player
        if (rb.velocity.magnitude < maxspeed)
        {
            Vector2 Desire = (Target.position - transform.position);
            rb.velocity += new Vector2(Desire.x * speed, Desire.y * speed);
        }
        else
        {
            rb.velocity -= rb.velocity * speed;
        }
    }

    private void Update()
    {
        //making the can rotate towards the direction it's going
        float Rotation = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, Rotation);
    }

    public void DestroyNow()
    {
        Destroy(this.gameObject);
    }
}