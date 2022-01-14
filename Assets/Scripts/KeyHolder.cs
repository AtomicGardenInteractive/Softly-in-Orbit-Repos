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
    }
    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("Added Key:" + keyType);
        keyList.Add(keyType);
    }    
    public bool ContainsKey(Key.KeyType keyType) 
    {        
        return keyList.Contains(keyType);
    }
    public void KeyDoor(Key.KeyType keyType) 
    {
        //Get Help
        // KeyScript here
        // Stop Player Moving when clicking on UI
        //if (ContainsKey(KeyDoor.GetKeyType())) 
        // for each ( var keytype in keylist)
        { 
            
        }
    } 
}