using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedMovement : Effects
{
    public override void Triggereffect(float duration)
    {
        Debug.Log("forced");
        InputManager.instance.forcedMoving = true;
        StartCoroutine(RefertEffect(duration));
    }

    private IEnumerator RefertEffect(float time)
    {
        yield return new WaitForSeconds(time);
        InputManager.instance.forcedMoving = false;
        InputManager.instance.NotMoving();
    }
}
