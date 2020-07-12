using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool paused;

    public GameObject endscreen;

    private void Awake()
    {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void ChanceScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ToggleTimeScale()
    {
        if(!paused)
        {
            Time.timeScale = 0;
            paused = true;
        }
        else
        {
            Time.timeScale = 1;
            paused = false;
        }
    }

    public void Gameover()
    {
        ToggleTimeScale();
        endscreen.SetActive(true);
    }

    public void Restart()
    {
        ToggleTimeScale();
        ChanceScene(0);
    }

    public void Close()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
