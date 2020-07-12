using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Effects
{
    public Color iceColor;
    public Color OriginalColor;

    public override void Triggereffect(float duration)
    {
        player.GetComponent<SpriteRenderer>().color = iceColor;

        player.inactiveControls = true;
        player.myRigidbody.sharedMaterial = player.withLimitedFriction;
        StartCoroutine(RefertEffect(duration));
    }

    private IEnumerator RefertEffect(float time)
    {
        yield return new WaitForSeconds(time);
        player.GetComponent<SpriteRenderer>().color = OriginalColor;
        player.inactiveControls = false;
        player.myRigidbody.sharedMaterial = player.withFriction;
    }
}
