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
    public GameObject redKeyItem;
    public GameObject blueKeyItem;
    public GameObject greenKeyItem;
    private static bool redKey = false;
    private static bool blueKey = false;
    private static bool greenKey = false;
    private void Start()
    {
        GameEvents.current.onGetKey += AddKey;
        GameEvents.current.onGamePause += PauseGame;
        GameEvents.current.onGameUnpause += UnpauseGame;
        redKeyItem.SetActive(false);
        blueKeyItem.SetActive(false);
        greenKeyItem.SetActive(false);
    }
    public void AddKey(Key.KeyType keyType)
    {
        if (keyType == Key.KeyType.Red) 
        {
            redKey = true;
        }
        else if (keyType == Key.KeyType.Blue)
        {
            blueKey = true;
        }
        else if (keyType == Key.KeyType.Green)
        {
            greenKey = true;
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
            if (redKey == true) { redKeyItem.SetActive(true); }
            if (blueKey == true) { blueKeyItem.SetActive(true); }
            if (greenKey == true) { greenKeyItem.SetActive(true); }
        }
    }
    public void CloseInventory() 
    {
        animator.SetBool("IsOpen", false);
        inventoryButton.SetActive(true);

    }
}
