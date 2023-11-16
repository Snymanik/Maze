using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Lock : MonoBehaviour
{

    [SerializeField]
    private Door door;
    [SerializeField]
    private KeyColor keyColour;
    private bool iCanOpen = false, isLocked = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            iCanOpen = true;
            Debug.Log("You can  use the lock");
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            iCanOpen = false;
            Debug.Log("You cannot use the lock");
        }
    }


}

