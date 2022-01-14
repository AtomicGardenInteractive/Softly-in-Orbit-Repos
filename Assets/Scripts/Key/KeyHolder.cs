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
    public void AddKey(Key.KeyType keyType)
    {
        //Debug.Log("Added Key:" + keyType);
        keyList.Add(keyType);
    }    
    public bool ContainsKey(Key.KeyType keyType) 
    {        
        return keyList.Contains(keyType);
    }
    public void KeyDoor(Key.KeyType keyType) 
    {
        //Debug.Log("KeyDoor called" + keyType);

        if (ContainsKey(keyType))
        {
            GameEvents.current.OpenDoor();
        }
        else
        {
            GameEvents.current.LockedDoor();
            Debug.Log("Has NOT got key");
        }
    } 
}
