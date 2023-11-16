using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Transform door, openPos, closePos;
    [SerializeField]
    private bool isOpen = false;
    [SerializeField]
    private float speed = 10f;
    private void Start()
    {
        door.position = closePos.position;
    }
    public void OpenClose()
    {
        isOpen = !isOpen;
    }
    private void Update()
    {
        if (isOpen && Vector3.Distance(door.position,openPos.position) > 0.001f)
        {

            door.position = Vector3.MoveTowards(door.position,openPos.position,speed * Time.deltaTime);
        }
        if (!isOpen && Vector3.Distance(door.position, closePos.position) > 0.001f)
        {

            door.position = Vector3.MoveTowards(door.position, closePos.position, speed * Time.deltaTime);
        }
    }
}
