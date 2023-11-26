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
    private Animator Animator;
    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

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

    public void UseKey()
    {
        door.OpenClose();
    }
    private void Update()
    {
        if (iCanOpen == true && !isLocked && Input.GetKeyDown(KeyCode.E)) 
        {
            Animator.SetBool("useKey", CheckTheKey());
        }
    }

    private bool CheckTheKey()
    {
        if(keyColour == KeyColor.Gold && GameManager.gameManager.goldKey > 0)
        {
            GameManager.gameManager.goldKey--;
            isLocked = true;
            return true;
        }
        else if (keyColour ==  KeyColor.Red && GameManager.gameManager.redKey > 0)
        {
            GameManager.gameManager.redKey--;
            isLocked = true;
            return true;
        }
        else if (keyColour ==  KeyColor.Silver && GameManager.gameManager.silverKey > 0)
        {
            GameManager.gameManager.silverKey--;
            isLocked = true;
            return true;
        }
        Debug.Log("You don't have the correct key");
        return false;
    }
}

