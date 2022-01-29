using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private string level;
    private void OnTriggerEnter(Collider collision)
    {       
        SceneManager.LoadScene(level);
    }
}
