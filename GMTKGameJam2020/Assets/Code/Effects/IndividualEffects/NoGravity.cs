using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGravity : Effects
{
    private float origGravityScale;
    public override void Triggereffect(float duration)
    {
        origGravityScale = player.myRigidbody.gravityScale;
        player.myRigidbody.gravityScale = 0f;
        StartCoroutine(RefertEffect(duration));
    }

    private IEnumerator RefertEffect(float time)
    {
        yield return new WaitForSeconds(time);
        player.myRigidbody.gravityScale = origGravityScale;
    }
}
