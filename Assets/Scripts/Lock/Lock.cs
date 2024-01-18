using System;
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
    [SerializeField]
    Material redMat, silverMat, goldMat;
    Renderer keyRenderer;
    Material[] KeyMaterials;
    const int INDEX_OF_COLOUR = 0;
    [SerializeField]
    Renderer lockRenderer;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        keyRenderer = GetComponent<Renderer>();
        GetComponentInParent<Renderer>();
        KeyMaterials = keyRenderer.materials;
        SetMyColour();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = true;
            Debug.Log("You can use the lock");
            // you can add if to (below) or you can change the check command entirely so that first is key then e 
            if (keyColour == KeyColor.Gold && GameManager.gameManager.goldKey > 0 || keyColour == KeyColor.Red && GameManager.gameManager.redKey > 0 ||
                keyColour == KeyColor.Silver && GameManager.gameManager.silverKey > 0)
            {
                if (!isLocked)
                {
                    GameManager.gameManager.SetUseText("Press E to use the key");
                }
            }else
            {
                if(!isLocked) {
                    GameManager.gameManager.SetUseText("Find the right key");
                }
                
            }
            
        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = false;
            Debug.Log("You cannot use the lock");
            GameManager.gameManager.SetUseText("");
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
        if (keyColour == KeyColor.Gold && GameManager.gameManager.goldKey > 0)
        {
            GameManager.gameManager.goldKey--;
            
            isLocked = true;
            GameManager.gameManager.SetKeyUI(keyColour);
            return true;
        }
        else if (keyColour == KeyColor.Red && GameManager.gameManager.redKey > 0)
        {
            GameManager.gameManager.redKey--;
            isLocked = true;
            GameManager.gameManager.SetKeyUI(keyColour);
            return true;
        }
        else if (keyColour == KeyColor.Silver && GameManager.gameManager.silverKey > 0)
        {
            
            GameManager.gameManager.silverKey--;
            isLocked = true;
            GameManager.gameManager.SetKeyUI(keyColour);
            return true;
        }
        
            Debug.Log("You don't have the correct key");
            return false;
        
        
    }
    private void SetMyColour()
    {
        switch (keyColour)
        {
            case KeyColor.Red:
                //keyRenderer.material = redMat;
                ReplaceKeyMaterial(redMat);
                lockRenderer.material = redMat;

                break;
            case KeyColor.Silver:
                ReplaceKeyMaterial(silverMat);
                lockRenderer.material = silverMat;
                break;
            case KeyColor.Gold:
                ReplaceKeyMaterial(goldMat);
                lockRenderer.material = goldMat;
                break;
        }

    }

    private void ReplaceKeyMaterial(Material material)
    {
        KeyMaterials[INDEX_OF_COLOUR] = material;
        keyRenderer.materials = KeyMaterials;
    }

}
    

