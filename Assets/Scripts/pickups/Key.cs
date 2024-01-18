using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Pickup
{
    [SerializeField]
    KeyColor keycolor;

    [SerializeField]
    Renderer keyRenderer;
    [SerializeField]
    Material redMat, silverMat, goldMat;
    public override void Picked()
    {
        base.Picked();
        GameManager.gameManager.AddKey(keycolor);
    }
    private void Start()
    {
        
        Colour();
    }
    private void Colour()
    {
        switch(keycolor)
        {
            case KeyColor.Red:
                keyRenderer.material = redMat;

                break;
            case KeyColor.Silver:

                keyRenderer.material = silverMat;
                break;
            case KeyColor.Gold:

                keyRenderer.material = goldMat;
                break;
        }

    }
}
