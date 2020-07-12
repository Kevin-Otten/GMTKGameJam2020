using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager instance;

    public List<Effects> allEffects = new List<Effects>();

    public PlayerManager player;

    private bool doubleEffect;

    [Space]

    public float minBetweenTime = 6;
    public float MaxBetweenTime = 8;
    public float effectDuration = 3;

    [Tooltip("use 0 - 100 for the persentage lower or higher than this will guarentee a outcome")]
    public float dubbleChanceValue = 10;

    public Image image1;
    public Image image2;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        QueNextEffect();

        foreach(Effects effect in allEffects)
        {
            effect.player = player;
        }
    }

    public void QueNextEffect()
    {
        float timeTillNextEffect = Random.Range(minBetweenTime, MaxBetweenTime);

        int nexteffectIndex = Random.Range(0, allEffects.Count);

        image1.enabled = true;

        image1.sprite = allEffects[nexteffectIndex].myIcon;

        StartCoroutine(TriggerEffect(timeTillNextEffect,allEffects[nexteffectIndex]));

        if(Random.Range(0, 100) <= dubbleChanceValue)
        {
            doubleEffect = true;
            image2.enabled = true;

            int nextDubbleffectIndex = nexteffectIndex;

            while(nextDubbleffectIndex == nexteffectIndex)
            {
                nextDubbleffectIndex = Random.Range(0, allEffects.Count - 1);
            }

            image2.sprite = allEffects[nextDubbleffectIndex].myIcon;

            StartCoroutine(TriggerEffect(timeTillNextEffect + 1, allEffects[nextDubbleffectIndex]));
        }
        else
        {
            image2.enabled = false;
        }
    }

    private IEnumerator TriggerEffect(float time, Effects effect)
    {
        yield return new WaitForSeconds(time);
        effect.Triggereffect(effectDuration);
        if (!doubleEffect)
            QueNextEffect();
        else
            doubleEffect = false;
    }
}
