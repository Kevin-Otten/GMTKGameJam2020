using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puke : Effects
{
    public ParticleSystem vomit;
    public override void Triggereffect(float duration)
    {
        vomit.Play();
        StartCoroutine(RefertEffect(duration));
    }

    private IEnumerator RefertEffect(float time)
    {
        yield return new WaitForSeconds(time);
        vomit.Stop();
    }
}
