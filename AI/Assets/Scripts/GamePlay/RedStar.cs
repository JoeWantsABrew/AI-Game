using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedStar : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D rb;
    public float speed;
    public string SpiderTag;
    public GameObject boomFX;
    
    private void Start()
    {
        GameObject thing = GameObject.FindObjectOfType<SPider>().gameObject;
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
        if (collision.collider.tag == SpiderTag)
        {
            Instantiate(boomFX, transform.position, transform.rotation);
        }
    }
}
