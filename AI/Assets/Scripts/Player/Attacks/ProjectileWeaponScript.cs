using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileWeaponScript : MonoBehaviour
{
    public Transform weaponProjectilePoint;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }       
    }
    void Shoot()
    {
        Instantiate(projectilePrefab, weaponProjectilePoint.position, weaponProjectilePoint.rotation);
    }

}
