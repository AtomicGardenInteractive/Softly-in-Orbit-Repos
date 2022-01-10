using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onGamePause;
    public void PauseGame()
    {
        if (onGamePause != null)
        {
            onGamePause();
        }
    }
    public event Action onGameUnpause;
    public void UnPauseGame()
    {
        if (onGameUnpause != null)
        {
            onGameUnpause();
        }
    }

    public event Action<string> onLoadLevel;
    public void LoadLevel(string levelToLoad)
    {
        if (onLoadLevel != null)
        {
            onLoadLevel(levelToLoad);
        }
    }
}
