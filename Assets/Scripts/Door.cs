using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Door : MonoBehaviour
{
    public GameObject doorLabel;
    public GameObject doorButton;
    public string levelToLoad;
    private static bool PlayerPresent = false;
    private static bool GameIsPaused = false;
    [SerializeField]
    private bool doorLocked;
    [SerializeField] 
    private Key.KeyType keyType;
    

    void Start()
    {
        GetComponentInChildren<Button>().onClick.RemoveAllListeners();
        GetComponentInChildren<Button>().onClick.AddListener(UseDoor);
        
        GameEvents.current.onGamePause += PauseGame;
        GameEvents.current.onGameUnpause += UnpauseGame;
        
        doorLabel.SetActive(false);
        doorButton.SetActive(false);
    }
    private void OnDestroy()
    {
        GameEvents.current.onGamePause -= PauseGame;
        GameEvents.current.onGameUnpause -= UnpauseGame;
    }
    void PauseGame()
    {
        GameIsPaused = true;
    }
    void UnpauseGame()
    {
        GameIsPaused = false;
    }

    void OnMouseEnter()
    {
        if
        (GameIsPaused == false)
        { 
         doorLabel.SetActive(true);        
        }

    }
    private void OnMouseExit()
    {
        if (!PlayerPresent)
        { 
            doorLabel.SetActive(false);        
        }
    }
    void Show()
    {
        doorLabel.SetActive(true);
        doorButton.SetActive(true);
    }
    void Hide()
    {
        doorLabel.SetActive(false);
        doorButton.SetActive(false);        
    }
    void OnTriggerEnter(Collider collision)
    {
        PlayerPresent = true;
        Show();        
    }
    void OnTriggerExit(Collider collision)
    {
        PlayerPresent = false;
        Hide();
    }

    public void UseDoor() 
    {
        if
        (!GameIsPaused)
        {
            if (!doorLocked)
            {
                GameEvents.current.LoadLevel(levelToLoad);
                Debug.Log("Door Activated, Load next Scene");
            }
            else 
            {
                GameEvents.current.KeyDoor(keyType);
                Debug.Log(keyType);
            }

        }
    }
}
