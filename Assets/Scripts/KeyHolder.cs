using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyHolder : MonoBehaviour
{
    [SerializeField]    
    private List<Key.KeyType> keyList;    
    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }
    private void Start()
    {
        GameEvents.current.onGetKey += AddKey;
        GameEvents.current.onKeyDoor += KeyDoor;
    }
    //adds key to the list
    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key:" + keyType);
        keyList.Add(keyType);
    }
    //Checks if the passed keytype is present in the list then returns
    public bool ContainsKey(Key.KeyType keyType) 
    {        
        return keyList.Contains(keyType);
    }
    //if the containskey returns then sends to open the door if not then sends the doorlocked which unsubbs the door from listening for open
    public void KeyDoor(Key.KeyType keyType) 
    {
        if (ContainsKey(keyType))
        {
            GameEvents.current.OpenDoor();
        }
        else
        {
            GameEvents.current.DoorLocked();
            Debug.Log("Door locked");
        }
    } 
}
