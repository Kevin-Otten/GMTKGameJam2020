using System.Collections;
using System.Collections.Generic;
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

    public GameObject imagePrefab;
    public RectTransform parent;
    public RectTransform start;
    public RectTransform target;

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

    public void CreateIcon(Sprite sprite, float TimeToTravel)
    {
        GameObject icon = Instantiate(imagePrefab, start.position, Quaternion.identity);
        icon.transform.SetParent(parent);

        Movingimage imageScript = icon.GetComponent<Movingimage>();
        imageScript.target = target;
        icon.GetComponent<Image>().sprite = sprite;
        imageScript.StartMovement(TimeToTravel);
    }

    public void QueNextEffect()
    {
        float timeTillNextEffect = Random.Range(minBetweenTime, MaxBetweenTime);

        int nexteffectIndex = Random.Range(0, allEffects.Count);

        StartCoroutine(TriggerEffect(timeTillNextEffect,allEffects[nexteffectIndex]));

        if(Random.Range(0, 100) <= dubbleChanceValue)
        {
            doubleEffect = true;
            Debug.Log("DoubleTrouble");
            int nextDubbleffectIndex = nexteffectIndex;

            while(nextDubbleffectIndex == nexteffectIndex)
            {
                nextDubbleffectIndex = Random.Range(0, allEffects.Count - 1);
            }

            StartCoroutine(TriggerEffect(timeTillNextEffect + 1, allEffects[nextDubbleffectIndex]));
        }
    }

    private IEnumerator TriggerEffect(float time, Effects effect)
    {
        CreateIcon(effect.myIcon, time);
        yield return new WaitForSeconds(time);
        effect.Triggereffect(effectDuration);
        if (!doubleEffect)
            QueNextEffect();
        else
            doubleEffect = false;
    }
}
