using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStarCollect : MonoBehaviour
{
    //tag for stars
    public string StarTag;
    
    //This function occurs anytime the object hits or "collides" with something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks if the tag is "StarTag"
        if (collision.collider.CompareTag(StarTag))
        {
            //every time the star is touched, 5 starpower is added
            //"playerprefs" is a thing that you can use to save variables on a device(like numbers)
            PlayerPrefs.SetInt("StarPower", PlayerPrefs.GetInt("StarPower") + 5);
            //Gets rid of the star
            Destroy(collision.gameObject);
        }
    }
}
