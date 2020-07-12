using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effects : MonoBehaviour
{
    public string effectID;

    public abstract void Triggereffect(float duration);
}
