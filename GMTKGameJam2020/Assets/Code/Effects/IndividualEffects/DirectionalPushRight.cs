using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalPushRight : Effects
{
    public float apliedForce;

    public override void Triggereffect(float duration)
    {
        Debug.Log("Pushed");
        player.myRigidbody.velocity = Vector2.up * apliedForce;
    }
}
