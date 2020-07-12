using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Effects
{
    public override void Triggereffect(float duration)
    {
        player.movementSpeed *= 2;
        StartCoroutine(RefertEffect(duration));
    }

    private IEnumerator RefertEffect(float time)
    {
        yield return new WaitForSeconds(time);
        player.movementSpeed /= 2;
    }
}
