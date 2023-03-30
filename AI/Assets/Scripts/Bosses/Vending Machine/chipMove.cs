using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chipMove : MonoBehaviour
{
    public Vector2 Will;
    public Rigidbody2D rb;
    public float speed;
    public float life;
    
    void Start()
    {
        Will = new Vector2(Random.Range(-200, 200), Random.Range(-200, 200)).normalized;
        rb = GetComponent<Rigidbody2D>();
        Invoke("Die", life);
    }

    void FixedUpdate()
    {
        rb.velocity = Will * speed;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
