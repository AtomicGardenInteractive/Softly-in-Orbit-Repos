using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    private static bool GameIsPaused = false;
    void Start()
    {
        GameEvents.current.onGamePause += PauseGame;
        GameEvents.current.onGameUnpause += UnpauseGame;
    }
    public enum KeyType 
    { 
            Red,
            Green,
            Blue
    }    
    private void OnMouseDown()
    {
        if (!GameIsPaused)
        {            
            GameEvents.current.GetKey(keyType);
            Destroy(this.gameObject);
        }
    }
    void PauseGame()
    {
        GameIsPaused = true;
    }
    void UnpauseGame()
    {
        GameIsPaused = false;
    }
}
