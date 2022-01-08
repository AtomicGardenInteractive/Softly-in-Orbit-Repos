using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public PauseScreen pauseScreen;
    public GameObject mouseOver;
    public GameObject mouseDown;

    
    void Start()
    {
        mouseOver.SetActive(false);
        mouseDown.SetActive(false);
    }
    void OnMouseEnter()
    {
        if
        (PauseScreen.GameIsPaused == false) 
        { 
            //Debug.Log("Mouse Over Active");
            mouseOver.SetActive(true); 
        }
    }
    void OnMouseExit()
    {
        if
         (PauseScreen.GameIsPaused == false)
        {   //Debug.Log("Mouse over Exit");
            mouseOver.SetActive(false);
            mouseDown.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        if
        (PauseScreen.GameIsPaused == false)
        {
            mouseOver.SetActive(false);
            mouseDown.SetActive(true);
        }
    }
}
