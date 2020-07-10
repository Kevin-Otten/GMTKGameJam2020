using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public void Awake()
    {
        InputManager.instance.MovingEvent += Move;
    }

    public void OnDestroy()
    {
        
    }

    public void Move(float xAxis)
    {

    }

    public void Die()
    {

    }
}
