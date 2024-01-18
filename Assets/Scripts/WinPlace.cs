using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class WinPlace : MonoBehaviour
{

    float alpha = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float scale = Resizer();
        this.transform.localScale = new Vector3 (scale, 6f, scale);
    }
    public float Resizer()
    {
        float value = Mathf.Sin(alpha);
        alpha += (1.5f * Time.deltaTime);
        return value  + 2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.gameManager.WinGame();
        }
    }

}
