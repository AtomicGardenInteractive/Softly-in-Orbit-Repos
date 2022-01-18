using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


public class PlayerScript : MonoBehaviour
{
    public LayerMask ground;

    private NavMeshAgent myAgent;

    private Animator playerAnimator;

    private static bool GameIsPaused = false;
    private static bool UIActive = false;

    public static PlayerScript Instance;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        playerAnimator = GetComponent<Animator>();

        GameEvents.current.onGamePause += PauseGame;
        GameEvents.current.onGameUnpause += UnpauseGame;
        GameEvents.current.onUIOpen += UIOpen;
        GameEvents.current.onUIClosed += UIClosed;
        
    }

    private void Update()
    {        
        //if (playerAnimator.velocity != Vector3.zero)
        //{
        //    playerAnimator.SetBool("isWalking", true);
        //}
        //else
        //{
        //    playerAnimator.SetBool("isWalking", false);
        //}
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