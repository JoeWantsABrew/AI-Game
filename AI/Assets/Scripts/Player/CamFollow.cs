using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float CamSpeed;
    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, CamSpeed * Time.deltaTime);  
    }
}
