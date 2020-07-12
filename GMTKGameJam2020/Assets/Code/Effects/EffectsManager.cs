using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public List<Effects> allEffects = new List<Effects>();

    [Space]

    public float minBetweenTime = 6;
    public float MaxBetweenTime = 8;
    public float effectDuration = 3;

    [Tooltip("use 0 - 100 for the persentage lower or higher than this will guarentee a outcome")]
    public float dubbleChanceValue = 10;

    private void Start()
    {
        QueNextEffect();
    }

    public void QueNextEffect()
    {
        float timeTillNextEffect = Random.Range(minBetweenTime, MaxBetweenTime);

        int nexteffectIndex = Random.Range(0, allEffects.Count - 1);

        StartCoroutine(TriggerEffect(timeTillNextEffect,allEffects[nexteffectIndex]));

        if(Random.Range(0, 100) <= dubbleChanceValue)
        {
            int nextDubbleffectIndex = Random.Range(0, allEffects.Count - 1);

            StartCoroutine(TriggerEffect(timeTillNextEffect + 1, allEffects[nextDubbleffectIndex]));
        }
    }

    private IEnumerator TriggerEffect(float time, Effects effect)
    {
        yield return new WaitForSeconds(time);
        effect.Triggereffect(effectDuration);
    }
}
