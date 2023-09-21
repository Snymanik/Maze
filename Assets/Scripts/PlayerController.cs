using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField]
    float speed = 12f;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();

    }
    private void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }
}
