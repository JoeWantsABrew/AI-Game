using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedStar : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D rb;
    public float speed;
    public string BossTag;
    public GameObject boomFX;
    
    private void Start()
    {
        GameObject thing = GameObject.FindObjectOfType<HealthManager>().gameObject;
        target = thing.GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 GoTo = (target.position - transform.position).normalized;
        rb.velocity = GoTo * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == BossTag)
        {
            Instantiate(boomFX, transform.position, transform.rotation);
        }
    }
}
