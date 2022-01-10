using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject mouseOver;
    public GameObject mouseDown;
    private static bool GameIsPaused;
    
    void Start()
    {
        mouseOver.SetActive(false);
        mouseDown.SetActive(false);

        GameEvents.current.onGamePause += PauseGame;
        GameEvents.current.onGameUnpause += UnpauseGame;
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
            //Debug.Log("Mouse Over Active");
            mouseOver.SetActive(true); 
        }
    }
    void OnMouseExit()
    {
        if
         (GameIsPaused == false)
        {   
            //Debug.Log("Mouse over Exit");
            mouseOver.SetActive(false);
            mouseDown.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        if
        (GameIsPaused == false)
        {
            mouseOver.SetActive(false);
            mouseDown.SetActive(true);
        }
    }
}