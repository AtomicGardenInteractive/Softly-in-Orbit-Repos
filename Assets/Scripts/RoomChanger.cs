using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChanger : MonoBehaviour
{
    [SerializeField] GameObject cameraPos1;
    [SerializeField] GameObject cameraPos2;
    private void OnTriggerEnter(Collider other)
    {
        if (Camera.main.transform.position == cameraPos1.transform.position)
        {
            Camera.main.transform.position = cameraPos2.transform.position;
        }
        else if (Camera.main.transform.position == cameraPos2.transform.position) 
        {
            Camera.main.transform.position = cameraPos1.transform.position;
        }
    }

}
