using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PointAdder : Pickup
{
    [SerializeField]
    int points = 5;
    public override void Picked()
    {
        base.Picked();
        GameManager.gameManager.AddPoints(points);
    }
}
