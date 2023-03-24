using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int[] BossHealth;
    public int[] MaxBossHealth;
    public int Phases;
    public int currentPhase;
    public string HurtTag;
    private bool valid = true;
    public bool alive = true;
    public GameObject DeathAnimation;
    public bool DestroyOnDeath;

    public void Update()
    {
        PlayerPrefs.SetInt("MaxBossHealth", MaxBossHealth[currentPhase - 1]);
        PlayerPrefs.SetInt("BossHealth", BossHealth[currentPhase - 1]);

        if (alive)
        {
            if (BossHealth[Phases - 1] <= 0)
            {
                GameObject.Find("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                alive = false;
                CamFollow kam = GameObject.FindObjectOfType<CamFollow>();
                kam.target = Instantiate(DeathAnimation, transform.position, transform.rotation).transform;
                kam.CamSpeed = 2;
                if (DestroyOnDeath)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(HurtTag))
        {
            if (valid)
            {
                valid = false;
                Invoke("REValidate", 0.2f);
                DamageDealer Stats = collision.collider.GetComponent<DamageDealer>();
                BossHealth[currentPhase - 1] -= Stats.Damage;
                Destroy(collision.gameObject);
            }
        }
    }

    public void REValidate()
    {
        valid = true;
    }
}
