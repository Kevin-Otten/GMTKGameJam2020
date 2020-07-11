using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusicSoundIncrease : MonoBehaviour
{
    public MainThemeController theme;
    private bool triggerd;
    public float newVolumeTarget;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!triggerd)
        {
            theme.SetNewVolume(newVolumeTarget);
            triggerd = true;
        }
    }
}
