using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Door : MonoBehaviour
{
    public GameObject doorLabel;
    public GameObject doorButton;    
    private static bool PlayerPresent = false;
    private static bool GameIsPaused = false;
    [SerializeField]
    private bool doorLocked;
    [SerializeField] 
    private Key.KeyType keyType;

    public Transform teleportTarget;
    public GameObject player;

    void Start()
    {
        GetComponentInChildren<Button>().onClick.RemoveAllListeners();
        GetComponentInChildren<Button>().onClick.AddListener(UseDoor);

        GameEvents.current.onGamePause += PauseGame;
        GameEvents.current.onGameUnpause += UnpauseGame;
        GameEvents.current.onOpenDoor += OpenDoor;
        doorLabel.SetActive(false);
        doorButton.SetActive(false);
    }
    private void OnDestroy()
    {
        GameEvents.current.onGamePause -= PauseGame;
        GameEvents.current.onGameUnpause -= UnpauseGame;
        GameEvents.current.onOpenDoor -= OpenDoor;
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
                Debug.Log("Door Not Locked");
                OpenDoor();
            }
            else 
            {
                GameEvents.current.KeyDoor(keyType);
                Debug.Log(keyType);
            }

        }
    }
    public void OpenDoor() 
    {
        gameObject.SetActive(false);

    }    
}
