using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movingimage : MonoBehaviour
{
    public RectTransform mytransform;
    public RectTransform target;

    float timeOfTravel;
    float currentTime = 0;
    float normalizedValue;

    void Start()
    {
        timeOfTravel = EffectsManager.instance.effectDuration;
        StartCoroutine(LerpObject());
    }
    //public void Update()
    //{
    //    mytransform.anchoredPosition = Vector3.Lerp(mytransform.position,target.position,)
    //}

    IEnumerator LerpObject()
    {

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel; // we normalize our time 

            mytransform.anchoredPosition = Vector3.Lerp(mytransform.anchoredPosition, target.anchoredPosition, normalizedValue);
            yield return null;
        }
    }
}
