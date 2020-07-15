using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : Effects
{
    private float shakeEnable;
    private int shakeTime = 0;
    private float cameraOrigX;
    private float cameraOrigY;
    public override void Triggereffect(float duration)
    {
        shakeEnable = 1;
        cameraOrigX = Camera.main.transform.position.x;
        cameraOrigY = Camera.main.transform.position.y;
        StartCoroutine(RefertEffect(duration));
    }

    private void Update() 
    {
            shakeTime++;
            if(shakeEnable == 1 && shakeTime >= 10)
            {
                Camera.main.transform.position = new Vector3 (cameraOrigX + Random.Range(-5.0f, 5.0f),cameraOrigY + Random.Range(-5.0f, 5.0f), Camera.main.transform.position.z);
                shakeTime = 0;
            }
    }

    private IEnumerator RefertEffect(float time)
    {
        yield return new WaitForSeconds(time);
        shakeEnable = 0;
        Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x , Camera.main.transform.position.y, Camera.main.transform.position.z);
    }
}
