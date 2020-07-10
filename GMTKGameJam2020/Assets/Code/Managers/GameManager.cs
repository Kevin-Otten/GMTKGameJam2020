using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool paused;

    private void Awake()
    {
        InputManager.instance.escapeEvent += TogglePauseGame;
    }

    public void TogglePauseGame()
    {
        if(!paused)
        {
            paused = true;
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            Time.timeScale = 1;
        }
    }
}
