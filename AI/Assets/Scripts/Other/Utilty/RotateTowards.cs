using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{

    public Transform Target;

    void Update()
    {

        Vector2 Delta = (Target.position - transform.position).normalized;
        transform.rotation = Quaternion.Euler(0, 0, ((Mathf.Atan2(Delta.y, Delta.x)) * Mathf.Rad2Deg) + 180);
    }
}
