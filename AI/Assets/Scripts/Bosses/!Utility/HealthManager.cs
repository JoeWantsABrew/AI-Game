using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    public int BossHealth;
    public int[] MaxBossHealth;
    public int Phases;
    public int currentPhase;
    public string HurtTag;
    private bool valid = true;
    public bool alive = true;
    public GameObject DeathAnimation;
    public bool DestroyOnDeath;
    public UnityEvent[] NextPhase;

    public void Update()
    {
        PlayerPrefs.SetInt("MaxBossHealth", MaxBossHealth[currentPhase]);
        PlayerPrefs.SetInt("BossHealth", BossHealth);
        if (currentPhase == Phases)
        {
            PlayerPrefs.SetString("FinalPhase", "true");
        }
        else
        {
            PlayerPrefs.SetString("FinalPhase", "false");
        }

        if (alive)
        {
            if (BossHealth <= 0)
            {
                if (currentPhase != Phases)
                {
                    currentPhase += 1;
                    alive = false;
                    BossHealth = MaxBossHealth[currentPhase];
                    alive = true;
                    NextPhase[currentPhase].Invoke();
                }
                else
                {
                    ProjectileHere[] Projectiles = GameObject.FindObjectsOfType<ProjectileHere>();
                    foreach (ProjectileHere thingy in Projectiles)
                    {
                        Destroy(thingy.gameObject);
                    }

                    if (DestroyOnDeath)
                    {
                        Destroy(this.gameObject);
                    }

                    GameObject.Find("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    alive = false;
                    CamFollow kam = GameObject.FindObjectOfType<CamFollow>();
                    kam.target = Instantiate(DeathAnimation, transform.position, transform.rotation).transform;
                    kam.CamSpeed = 2;
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
                DamageDealer Stats = collision.collider.GetComponent<DamageDealer>();
                BossHealth -= Stats.Damage;
                Destroy(collision.gameObject);
                REValidate();
            }
        }
    }

    public void REValidate()
    {
        valid = true;
    }

    private void Start()
    {
        PlayerPrefs.SetString("FinalPhase", "false");
    }
}
