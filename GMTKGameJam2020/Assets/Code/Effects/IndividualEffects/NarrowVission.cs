using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrowVission : Effects
{
    public float CameraSize = 1;
    public override void Triggereffect(float duration)
    {
        Camera.main.orthographicSize = CameraSize;
        StartCoroutine(RefertEffect(duration));
    }

    private IEnumerator RefertEffect(float time)
    {
        yield return new WaitForSeconds(time);
        Camera.main.orthographicSize = 6;
    }
}
