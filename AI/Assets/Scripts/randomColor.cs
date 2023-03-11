using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomColor : MonoBehaviour
{
    public Color randColor;
    public SpriteRenderer sproot;

    private void Start()
    {
        sproot = GetComponent<SpriteRenderer>();
        float r = Random.Range(100, 255);
        float b = Random.Range(100, 255);
        float g = Random.Range(100, 255);

        Color cool = new Color(r / 255, g / 255, b / 255, 1);
        sproot.color = cool;
        var scalee = Random.Range(0.3f, 1.5f);
        transform.localScale = new Vector3(scalee, scalee, scalee);

        float x = Random.Range(-200, 200);
        float y = Random.Range(-200, 200);
        float z = Random.Range(20, 90);
        transform.position = new Vector3(x, y, z);
    }
}
