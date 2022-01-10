using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public void Start()
    {
        GameEvents.current.onLoadLevel += LoadLevel;
    }

    public void LoadLevel(string levelToLoad)
    {              
        Debug.Log("Scene Tried to Load");
        Debug.Log(levelToLoad);
        SceneManager.LoadScene(levelToLoad);
    }
}
