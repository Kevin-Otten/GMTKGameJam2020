using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseControls : Effects
{
    public override void Triggereffect(float duration)
    {
        player.inverseControls = true;
        StartCoroutine(RefertEffect(duration));
    }

    private IEnumerator RefertEffect(float time)
    {
        yield return new WaitForSeconds(time);
        player.inverseControls = false;
    }
}