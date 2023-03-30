using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipsExplode : MonoBehaviour
{
    public int MaxChipCount;
    public int MinChipCount;
    private int ChoseChipCount;

    public float fuse;
    public float force;

    public Rigidbody2D rb;

    public GameObject Chip;

    private int ExistingChips = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Transform Target = GameObject.FindObjectOfType<PlayerMovement>().transform;
        rb.velocity = (Target.position - transform.position).normalized * force;
        InvokeRepeating("Explode", fuse, 0.01f);
        ChoseChipCount = Random.Range(MinChipCount - 1, MaxChipCount);
    }

    public void Explode()
    {
        if (ExistingChips < ChoseChipCount)
        {
            Instantiate(Chip, transform.position, transform.rotation);
            ExistingChips++;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
