using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movingimage : MonoBehaviour
{
    public RectTransform mytransform;
    public RectTransform target;

    float currentTime = 0;

    void Start()
    {
        mytransform = GetComponent<RectTransform>();
    }
    public void StartMovement(float time)
    {
        StartCoroutine(LerpObject(time));
    }

    IEnumerator LerpObject(float timeToSpend)
    {
        float timeOfTravel = timeToSpend;
        float t = 0f;
        Vector2 currentPos = mytransform.localPosition;

        while (t <= 1)
        {
            t += Time.deltaTime / timeOfTravel;

            mytransform.anchoredPosition = Vector3.Lerp(currentPos, target.localPosition, t);

            yield return null;
        }

        Destroy(gameObject);
    }
}
