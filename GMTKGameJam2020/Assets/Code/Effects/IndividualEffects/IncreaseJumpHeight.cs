using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseJumpHeight : Effects
{
    public override void Triggereffect(float duration)
    {
        player.jumpForce *= 2;
        StartCoroutine(RefertEffect(duration));
    }

    private IEnumerator RefertEffect(float time)
    {
        yield return new WaitForSeconds(time + 2);
        player.jumpForce /= 2;
    }
}
