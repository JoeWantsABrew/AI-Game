using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Player;

    private void Start()
    {
        Player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
    }

    public void Fire()
    {
        if (PlayerPrefs.GetInt("StarPower") >= 5)
        {
            Instantiate(Bullet, Player.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("StarPower", PlayerPrefs.GetInt("StarPower") - 5);
        }
    }
}
