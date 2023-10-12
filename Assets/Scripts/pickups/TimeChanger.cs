using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChanger : Pickup
{
    [SerializeField]
    bool isAddingTime;
    [SerializeField]
    int time = 5;

    public override void Picked()
    {
        base.Picked();
        GameManager.gameManager.AddTime(time * calculateSing()); 
    }
    private int calculateSing()
    {
        int sign;
        if (isAddingTime) sign = 1;
        else sign = -1;
        
        return sign;
    }
}
