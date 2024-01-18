using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColourToPrefab[] colourMappings;
    public float offset = 5f;
    public Material mat01, mat02;

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if (pixelColor.a == 0) return;


        foreach(ColourToPrefab colourMapings in colourMappings)
        {
            if (colourMapings.Color.Equals(pixelColor))
            {
                Vector3 positon  = new Vector3(x,0,z) * offset;
                Instantiate(colourMapings.prefab, positon, Quaternion.identity, transform);
            }
        }
    }
    public void generateLabyrinth()
    {
        for(int x=0; x<map.width; x++)
        {
            for(int  z=0; z<map.height; z++)
            {
                GenerateTile(x,z);
            }
        }
        ColourTheChildren();
    }
    private void ColourTheChildren()
    {
            foreach(Transform child in transform)
        {

            if(child.tag == "Wall")
            {
                if(Random.Range(1,100) % 3 == 0)
                {
                    child.gameObject.GetComponent<Renderer>().material = mat01;
                }else child.gameObject.GetComponent<Renderer>().material = mat02;
            }
            if(child.childCount > 0)
            {
                foreach (Transform grandchild in child.transform)
                {

                    if (grandchild.tag == "Wall")
                    {
                        if (Random.Range(1, 100) % 3 == 0)
                        {
                            grandchild.gameObject.GetComponent<Renderer>().material = mat01;
                        }
                        else grandchild.gameObject.GetComponent<Renderer>().material = mat02;
                    }
                }
            }
        }
    }
}

