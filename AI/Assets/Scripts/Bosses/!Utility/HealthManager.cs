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

    private void Update()
    {
        PlayerPrefs.SetInt("MaxBossHealth", MaxBossHealth[currentPhase]);
        PlayerPrefs.SetInt("BossHealth", BossHealth[currentPhase]);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == HurtTag)
        {
            DamageDealer Stats = collision.collider.GetComponent<DamageDealer>();
            BossHealth[currentPhase] -= Stats.Damage;
            Destroy(collision.collider.gameObject);
        }
    }
}
