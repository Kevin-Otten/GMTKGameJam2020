using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : Effects
{
    public float shakeWidth;
    public float shakeAmount;
    private int shakeEnable;
    private int shakeTime;
    public override void Triggereffect(float duration)
    {
        shakeEnable = 1;
        StartCoroutine(RefertEffect(duration));
    }

    private void Update() 
    {
            shakeTime++;
            if(shakeEnable == 1 && shakeTime >= shakeAmount)
            {
                Camera.main.transform.position = new Vector3 (player.transform.position.x + Random.Range(-shakeWidth, shakeWidth),player.transform.position.y + Random.Range(-shakeWidth, shakeWidth), Camera.main.transform.position.z);
                shakeTime = 0;
            }
    }

    private IEnumerator RefertEffect(float time)
    {
        yield return new WaitForSeconds(time);
        shakeEnable = 0;
    }
}
