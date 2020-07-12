using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHitBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.GetComponent<PlayerManager>())
        {
            collision.transform.GetComponent<PlayerManager>().Death();
        }
    }
}
