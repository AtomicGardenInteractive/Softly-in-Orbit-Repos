using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
public class Door : MonoBehaviour
{
    private PauseScreen pauseScreen;

    public GameObject doorLabel;
    public GameObject doorButton;
    private static bool PlayerPresent = false;
    
    void Start()
    {
        doorLabel.SetActive(false);
        doorButton.SetActive(false);
    }

    void OnMouseEnter()
    {
        if
        (PauseScreen.GameIsPaused == false)
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
    void OnTriggerEnter(Collider collider)
    {
        PlayerPresent = true;
        Show();
        
    }
    void OnTriggerExit(Collider collider)
    {
        PlayerPresent = false;
        Hide();

    }

    public void UseDoor() 
    {
        if
        (PauseScreen.GameIsPaused == false)
        {
            Debug.Log("Door Way Activated, Load next Scene");
        }
    }
}
