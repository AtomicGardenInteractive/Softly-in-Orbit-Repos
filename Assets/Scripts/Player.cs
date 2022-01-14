using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public LayerMask ground;

    private NavMeshAgent myAgent;

    private static bool GameIsPaused = false;
    private static bool UIActive = false;
    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();

        GameEvents.current.onGamePause += PauseGame;
        GameEvents.current.onGameUnpause += UnpauseGame;
        GameEvents.current.onUIOpen += UIOpen;
        GameEvents.current.onUIClosed += UIClosed;
    }
    void PauseGame()
    {
        GameIsPaused = true;
    }
    void UnpauseGame()
    {
        GameIsPaused = false;
    }
    void UIOpen() 
    { 
        UIActive = true; 
    }
    void UIClosed()
    {
        UIActive = false;
    }
    public void Click(InputAction.CallbackContext context)
    {
        //Debug.Log("Click" + context.phase);
        if (!GameIsPaused)
        {
            if (!UIActive)
            {
                Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;


                if (Physics.Raycast(myRay, out hitInfo, 100, ground))
                {
                    myAgent.SetDestination(hitInfo.point);
                }
            }
        }   
    }
    
}