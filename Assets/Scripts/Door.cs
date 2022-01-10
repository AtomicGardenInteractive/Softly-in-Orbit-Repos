using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door : MonoBehaviour
{
    public GameObject doorLabel;
    public GameObject doorButton;
    public string levelToLoad;
    private static bool PlayerPresent = false;
    private static bool GameIsPaused = false;
       
    void Start()
    {
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
        (GameIsPaused == false)
        {            
            GameEvents.current.LoadLevel(levelToLoad);
            Debug.Log("Door Activated, Load next Scene");
        }
    }
}
