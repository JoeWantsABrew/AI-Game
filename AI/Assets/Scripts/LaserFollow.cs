using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFollow : MonoBehaviour
{
    public GameObject target;
    public Vector2 goTO;
    public float speed;
    public Rigidbody2D thisss;

    private void Start()
    {
        target = (GameObject.Find("Player"));
        goTO = (target.transform.position - transform.position).normalized;
    }
    private void Update()
    {
        float quat = Mathf.Atan2(thisss.velocity.y, thisss.velocity.x) * Mathf.Rad2Deg + 90;
        Quaternion accRotation = Quaternion.Euler(0, 0, quat);
        transform.rotation = accRotation;
        thisss.velocity = goTO * speed;
    }
}
