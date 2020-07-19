using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScalePulsating : Effects
{
    private int scaleEnable;
    private float myScale = 1;
    public override void Triggereffect(float duration)
    {
        scaleEnable = 1;
        StartCoroutine(RefertEffect(duration));
    }

    private void Update() 
    {
            //shakeTime++;
            if(scaleEnable == 1)
            {
                myScale = myScale++;
                player.transform.localScale = new Vector2(myScale, myScale);
            }
    }

    private IEnumerator RefertEffect(float time)
    {
        yield return new WaitForSeconds(time);
        scaleEnable = 0;
        player.transform.localScale = new Vector3(1, 1, 1);
    }
}
