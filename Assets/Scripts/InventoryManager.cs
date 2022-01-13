using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Animator animator;
    private static bool GameIsPaused;
    public GameObject inventoryButton;
    public GameObject inventoryWindow;


    private void Start()
    {
        GameEvents.current.onGamePause += PauseGame;
        GameEvents.current.onGameUnpause += UnpauseGame;
    }
    void PauseGame()
    {
        GameIsPaused = true;
    }
    void UnpauseGame()
    {
        GameIsPaused = false;
    }
    private void Update()
    {
        if (GameIsPaused)
        {
            inventoryButton.SetActive(true);
            inventoryWindow.SetActive(false);
        }
    }

    public void OpenInventory() 
    {
        if (!GameIsPaused) 
        {   
            inventoryWindow.SetActive(true);         
            Debug.Log("Open Inventory");
            animator.SetBool("IsOpen", true);
            inventoryButton.SetActive(false);
            
        }
    }
    public void CloseInventory() 
    {
        animator.SetBool("IsOpen", false);
        inventoryButton.SetActive(true);

    }
}
