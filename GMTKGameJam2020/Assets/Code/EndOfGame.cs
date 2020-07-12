using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGame : MonoBehaviour
{
    private bool used;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!used)
        {
            used = true;
            GameManager.instance.Gameover();

            Destroy(gameObject);
        }
    }
}
