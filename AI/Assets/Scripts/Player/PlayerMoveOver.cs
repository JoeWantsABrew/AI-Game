using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveOver : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 move;
    public float speed;
    public Joystick joy;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joy = FindObjectOfType<Joystick>();
    }
    private void FixedUpdate()
    {
        move = new Vector2(joy.Horizontal, joy.Vertical);
        rb.velocity = move * speed;
    }
}
