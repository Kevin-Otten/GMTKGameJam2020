using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSavedPositions : MonoBehaviour
{
    public PlayerManager player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.LastPositions.Clear();
        player.LastPositions.Add(player.transform.position);

        Destroy(gameObject);
    }
}
