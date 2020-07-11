using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public List<Effects> allEffects = new List<Effects>();

    public float minBetweenTime;
    public float MaxBetweenTime;

    [Tooltip("use 0 - 100 for the persentage lower or higher than this will guarentee a outcome")]
    public float dubbleChanceValue = 10;

    private void Start()
    {
        
    }

    public void QueNextEffect()
    {

    }
}
