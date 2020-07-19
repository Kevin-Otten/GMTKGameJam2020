using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGravity : Effects
{
    private float origGravityScale;
    public override void Triggereffect(float duration)
    {
        origGravityScale = player.myRigidbody.gravityScale;
        player.myRigidbody.gravityScale = -origGravityScale;
        player.transform.localRotation = Quaternion.Euler(180, 0, 0);
        player.jumpForce = -12;
        StartCoroutine(RefertEffect(duration));
    }

    private IEnumerator RefertEffect(float time)
    {
        yield return new WaitForSeconds(time + 2);
        player.myRigidbody.gravityScale = origGravityScale;
        player.transform.localRotation = Quaternion.Euler(0, 0, 0);
        player.jumpForce = 12;
    }
}
