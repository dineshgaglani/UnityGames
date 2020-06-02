using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Bird>() != null)
        {
            //Anything other than it collides with will break it
            Debug.Log("Collision!");
            Destroy(gameObject);
        } 
    }


}
