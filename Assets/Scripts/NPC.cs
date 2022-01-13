using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject mouseOver;    
    private static bool GameIsPaused = false;
    public Dialogue dialogue;

    void Start()
    {
        mouseOver.SetActive(false);       

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
        (!GameIsPaused)
        {
            //Debug.Log("Mouse Over Active");
            mouseOver.SetActive(true);
        }
    }
    void OnMouseExit()
    {
        //Debug.Log("Mouse over Exit");
        mouseOver.SetActive(false);
    }
    private void OnMouseDown()
    {
        TriggerDialogue();
    }   

    public void TriggerDialogue()
    {
        GameEvents.current.TriggerDialogue(dialogue);
    }
}
