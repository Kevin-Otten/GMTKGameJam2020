using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;

        InputManager.instance.escapeEvent += TogglePauseGame;
    }

    private void OnDestroy()
    {
        InputManager.instance.escapeEvent -= TogglePauseGame;
    }

    public void TogglePauseGame()
    {

        if (!GameManager.instance.paused)
        {
            //Open pause menu
        }
        else
        {
            //Close pause menu
        }

        GameManager.instance.ToggleTimeScale();
    }
}
