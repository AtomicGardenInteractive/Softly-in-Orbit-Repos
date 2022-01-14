using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScreen : MonoBehaviour
{
    
    private static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject OptionsMenuUI;

    public InputMasterControls controls;

    void Awake ()
    {
        controls = new InputMasterControls();
        controls.Player.Menu.performed += ctx => PauseMenu();
    }

    public void PauseMenu()
    {       
        //Debug.Log("ESC");
        if (GameIsPaused)
        {
            Resume();

        }
        else 
        {
            Pause();
        }
    }
    void Resume()
    {
        GameEvents.current.UIClosed();
        pauseMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameEvents.current.UnPauseGame();
    }

    void Pause()
    {
        GameEvents.current.UIOpen();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameEvents.current.PauseGame();
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
