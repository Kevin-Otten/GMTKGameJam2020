using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Effects : MonoBehaviour
{
    public PlayerManager player;

    public string effectID;

    public Sprite myIcon;

    public abstract void Triggereffect(float duration);
}
