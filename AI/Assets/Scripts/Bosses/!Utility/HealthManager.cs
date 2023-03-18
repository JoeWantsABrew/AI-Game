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

    public void Update()
    {
        PlayerPrefs.SetInt("MaxBossHealth", MaxBossHealth[currentPhase - 1]);
        PlayerPrefs.SetInt("BossHealth", BossHealth[currentPhase - 1]);
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
