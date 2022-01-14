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
    public event Action onUIOpen;
    public void UIOpen()
    {
        if (onUIOpen != null)
        {
            onUIOpen();
        }
    }
    public event Action onUIClosed;
    public void UIClosed()
    {
        if (onUIClosed != null)
        {
            onUIClosed();
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
    public event Action<Dialogue> onTriggerDialogue;
    public void TriggerDialogue(Dialogue dialogue)
    {
        if (onTriggerDialogue != null)
        {
            onTriggerDialogue(dialogue);
        }
    }
    public event Action<Key.KeyType> onGetKey;
    public void GetKey(Key.KeyType keyType)
    {
        if (onGetKey != null)
        {
            onGetKey(keyType);
        }
    }
    public event Action<Key.KeyType> onKeyDoor;
    public void KeyDoor(Key.KeyType keyType)
    {
        if (onKeyDoor != null)
        {
            onKeyDoor(keyType);
        }
    }
    public event Action onOpenDoor;
    public void OpenDoor()
    {
        if (onOpenDoor != null)
        {
            onOpenDoor();
        }
    }
    public event Action onLockedDoor;
    public void LockedDoor()
    {
        if (onLockedDoor != null)
        {
            onLockedDoor();
        }
    }
}
